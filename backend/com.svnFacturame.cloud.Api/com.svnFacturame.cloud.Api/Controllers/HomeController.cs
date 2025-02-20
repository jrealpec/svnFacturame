using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace com.svnFacturame.cloud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [Route("Test_Swagger")]
        [HttpGet]
        public async Task<string> TestSwagger() { return "Hello SwaggerUI"; }
    }
}
