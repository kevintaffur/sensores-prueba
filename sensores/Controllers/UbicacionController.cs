using Microsoft.AspNetCore.Mvc;
using sensores.Dtos.Sensores;
using sensores.Dtos.Ubicaciones;
using sensores.Exceptions;
using sensores.Repositories.UbicacionRepository;
using sensores.Services.SensorService;
using sensores.Services.UbicacionService;
using sensores.Utils;

namespace sensores.Controllers
{
    [ApiController]
    [Route("api/v1/ubicaciones")]
    public class UbicacionController : ControllerBase
    {
        private readonly IUbicacionService _service;

        public UbicacionController(IUbicacionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            try
            {
                return Ok(new CustomResponse
                {
                    StatusCode = 200,
                    Message = "Ubicaciones obtenidas satisfactoriamente.",
                    Content = await _service.ObtenerTodos()
                });
            }
            catch (CustomException ex)
            {
                return NotFound(new CustomResponse
                {
                    StatusCode = 404,
                    Message = ex.Message,
                    Content = null
                });
            }
        }

        [HttpGet("{ubicacionId:int}")]
        public async Task<IActionResult> ObtenerPorId([FromRoute] int ubicacionId)
        {
            try
            {
                return Ok(new CustomResponse
                {
                    StatusCode = 200,
                    Message = "Ubición obtenida satisfactoriamente.",
                    Content = await _service.ObtenerPorId(ubicacionId)
                });
            }
            catch (CustomException ex)
            {
                return NotFound(new CustomResponse
                {
                    StatusCode = 404,
                    Message = ex.Message,
                    Content = null
                });
            }
        }


        [HttpPut("{ubicacionId:int}")]
        public async Task<IActionResult> Modificar([FromRoute] int ubicacionId, [FromBody] UbicacionModificacionDto modificacion)
        {
            try
            {
                return Ok(new CustomResponse
                {
                    StatusCode = 200,
                    Message = "Ubicación modificada satisfactoriamente.",
                    Content = await _service.Modificar(ubicacionId, modificacion)
                });
            }
            catch (CustomException ex)
            {
                return NotFound(new CustomResponse
                {
                    StatusCode = 404,
                    Message = ex.Message,
                    Content = null
                });
            }
        }


        [HttpDelete("{ubicacionId:int}")]
        public async Task<IActionResult> Eliminar([FromRoute] int ubicacionId)
        {
            try
            {
                await _service.Eliminar(ubicacionId);
                return Ok(new CustomResponse
                {
                    StatusCode = 200,
                    Message = "Ubicación eliminada satisfactoriamente.",
                    Content = null
                });
            }
            catch (CustomException ex)
            {
                return NotFound(new CustomResponse
                {
                    StatusCode = 404,
                    Message = ex.Message,
                    Content = null
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] UbicacionCreacionDto creacion)
        {
            try
            {
                return Created("", new CustomResponse
                {
                    StatusCode = 201,
                    Message = "Ubicación creada satisfactoriamente.",
                    Content = await _service.Crear(creacion)
                });
            }
            catch (CustomException ex)
            {
                return BadRequest(new CustomResponse
                {
                    StatusCode = 400,
                    Message = ex.Message,
                    Content = null
                });
            }
        }
    }
}
