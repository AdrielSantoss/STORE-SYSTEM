using OpenIddict.Server;
using static OpenIddict.Server.OpenIddictServerEvents;

namespace StoreSystem.Api.Authentication
{
    public class TokenHandler : IOpenIddictServerHandler<HandleTokenRequestContext>
    {
        public TokenHandler()
        {}

        public async ValueTask HandleAsync(HandleTokenRequestContext context)
        {}
    }
}
