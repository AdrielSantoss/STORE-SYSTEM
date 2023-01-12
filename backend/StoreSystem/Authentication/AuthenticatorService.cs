using static OpenIddict.Abstractions.OpenIddictConstants;
using static OpenIddict.Server.OpenIddictServerEvents;


namespace StoreSystem.Api.Authentication
{
    public static class AuthenticatorService 
    {
        public static void AddStoreSystemOpenIdConnect(this IServiceCollection services, string[] authorities, bool requireHttps)
        {
            for (var i = 0; i < authorities.Length; i++)
            {
                var authority = authorities[i];

                services.AddAuthentication("Bearer0").AddOpenIdConnect("Bearer" + i, options =>
                    {
                        options.ClientId = "Store.System";
                        options.Authority = authority;
                        options.RequireHttpsMetadata = requireHttps;
                    });
            }
        }

        public static void AddCommercioOpenIddictServer(this IServiceCollection services, bool requireHttps)
        {
            // https://kevinchalet.com/2020/02/18/creating-an-openid-connect-server-proxy-with-openiddict-3-0-s-degraded-mode/
            // https://github.com/openiddict/openiddict-samples/blob/dev/samples/Imynusoph/Imynusoph.Server/Startup.cs

            // Register the OpenIddict server components.
            services.AddOpenIddict()
                .AddServer(options =>
                {
                    // Enable the token endpoint.
                    options.SetTokenEndpointUris("/api/connect/token");

                    // Enable the password and the refresh token flows.
                    options.AllowPasswordFlow()
                           .AllowClientCredentialsFlow()
                           .AllowRefreshTokenFlow();

                    // Register the allowed scopes for the discovery document
                    options.RegisterScopes(Scopes.OpenId, Scopes.OfflineAccess);

                    // Enable the degraded mode to allow using the server feature without a backing database.
                    options.EnableDegradedMode();

                    // Accept anonymous clients (i.e clients that don't send a client_id).
                    options.AcceptAnonymousClients();

                    // Register the signing and encryption credentials.
                    options.AddDevelopmentEncryptionCertificate()
                           .AddDevelopmentSigningCertificate();

                    options.UseAspNetCore(builder =>
                    {
                        if (!requireHttps)
                        {
                            builder.DisableTransportSecurityRequirement();
                        }
                    });

                    // Register an event handler responsible of validating token requests.
                    options.AddEventHandler<ValidateTokenRequestContext>(builder =>
                        builder.UseInlineHandler(context =>
                        {
                            // Client authentication is not used, so there's nothing specific to validate here.
                            return default;
                        }));

                    // Register an event handler responsible of handling token requests.
                    options.AddEventHandler<HandleTokenRequestContext>(builder => builder.UseScopedHandler<TokenHandler>());
                })

                // Register the OpenIddict validation components.
                .AddValidation(options =>
                {
                    // Import the configuration from the local OpenIddict server instance.
                    options.UseLocalServer();

                    // Register the ASP.NET Core host.
                    options.UseAspNetCore();
                });
        }
    }
}
