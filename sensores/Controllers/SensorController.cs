using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sensores.Dtos.Sensores;
using sensores.Exceptions;
using sensores.Services.SensorService;
using sensores.Utils;

namespace sensores.Controllers
{
    [ApiController]
    [Route("api/v1/sensores")]
    [Authorize]
    public class SensorController : ControllerBase
    {
        private readonly ISensorService _service;

        public SensorController(ISensorService service)
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
                    Message = "Sensores obtenidos satisfactoriamente.",
                    Content = await _service.ObtenerTodos()
                });
            } catch(CustomException ex)
            {
                return NotFound(new CustomResponse
                {
                    StatusCode = 404,
                    Message = ex.Message,
                    Content = null
                });
            }
        }

        [HttpGet("{sensorId:int}")]
        public async Task<IActionResult> ObtenerPorId([FromRoute] int sensorId)
        {
            try
            {
                return Ok(new CustomResponse
                {
                    StatusCode = 200,
                    Message = "Sensor obtenido satisfactoriamente.",
                    Content = await _service.ObtenerPorId(sensorId)
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


        [HttpPut("{sensorId:int}")]
        public async Task<IActionResult> Modificar([FromRoute] int sensorId, [FromBody] SensorModificacionDto modificacion)
        {
            try
            {
                return Ok(new CustomResponse
                {
                    StatusCode = 200,
                    Message = "Sensor modificado satisfactoriamente.",
                    Content = await _service.Modificar(sensorId, modificacion)
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


        [HttpDelete("{sensorId:int}")]
        public async Task<IActionResult> Eliminar([FromRoute] int sensorId)
        {
            try
            {
                await _service.Eliminar(sensorId);
                return Ok(new CustomResponse
                {
                    StatusCode = 200,
                    Message = "Sensor eliminado satisfactoriamente.",
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
        public async Task<IActionResult> Crear([FromBody] SensorCreacionDto creacion)
        {
            try
            {
                return Created("", new CustomResponse
                {
                    StatusCode = 201,
                    Message = "Sensor creado satisfactoriamente.",
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
