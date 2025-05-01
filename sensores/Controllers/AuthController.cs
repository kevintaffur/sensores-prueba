using Azure;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using sensores.Services;
using sensores.Utils;

namespace sensores.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private JwtService Service;

        public AuthController(JwtService service)
        {
            Service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] string nombre)
        {
            try
            {
                if (nombre.Equals("kevin"))
                {
                    var token = Service.GenerarToken(nombre);
                    return Ok(new CustomResponse
                    {
                        StatusCode = 200,
                        Message = "Sesión iniciada satisfactoriamente.",
                        Content = token
                    });
                }
                return Unauthorized(new CustomResponse
                {
                    StatusCode = 401,
                    Message = "Datos incorrectos",
                    Content = null
                });
            }
            catch
            {
                return Unauthorized(new CustomResponse
                {
                    StatusCode = 401,
                    Message = "Datos incorrectos",
                    Content = null
                });
            }
        }
    }
}
