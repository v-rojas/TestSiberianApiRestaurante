
using ApiRestaurante.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAutenticacionJWT autenticacionJWT;

        public AuthenticationController(IAutenticacionJWT autenticacionJWT)
        {
            this.autenticacionJWT = autenticacionJWT;
        }

        [HttpGet]
        [Route("token")]
        public IActionResult Get()
        {
            object o = autenticacionJWT.Autenticacion();
            return Ok(o);
        }
    }
}
