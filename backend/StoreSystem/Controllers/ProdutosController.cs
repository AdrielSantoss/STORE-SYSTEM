using Microsoft.AspNetCore.Mvc;

namespace StoreSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProdutosController : ControllerBase
    {
        public ProdutosController()
        { }

        [HttpGet]
        public async Task<IActionResult> GetProdutosAsync()
        {
            return Ok(); // continua
        }
    }
}
