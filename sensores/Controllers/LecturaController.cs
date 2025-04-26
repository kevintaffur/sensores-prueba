using Microsoft.AspNetCore.Mvc;
using sensores.Dtos.Lecturas;
using sensores.Dtos.Sensores;
using sensores.Exceptions;
using sensores.Services.LecturaService;
using sensores.Services.SensorService;
using sensores.Utils;

namespace sensores.Controllers
{
    [ApiController]
    [Route("api/v1/lecturas")]
    public class LecturaController : ControllerBase
    {
        private readonly ILecturaService _service;

        public LecturaController(ILecturaService service)
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
                    Message = "Lecturas obtenidas satisfactoriamente.",
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

        [HttpGet("{lecturaId:int}")]
        public async Task<IActionResult> ObtenerPorId([FromRoute] int lecturaId)
        {
            try
            {
                return Ok(new CustomResponse
                {
                    StatusCode = 200,
                    Message = "Lectura obtenida satisfactoriamente.",
                    Content = await _service.ObtenerPorId(lecturaId)
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
        public async Task<IActionResult> Crear([FromBody] LecturaCreacionDto creacion)
        {
            try
            {
                return Created("", new CustomResponse
                {
                    StatusCode = 201,
                    Message = "Lectura creada satisfactoriamente.",
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

        [HttpGet("filtro/{sensorId:int}")]
        public async Task<IActionResult> ObtenerTodos([FromRoute] int sensorId,
            [FromQuery] DateOnly inicio,
            [FromQuery] DateOnly fin)
        {
            try
            {
                return Ok(new CustomResponse
                {
                    StatusCode = 200,
                    Message = "Lecturas obtenidas satisfactoriamente.",
                    Content = await _service.ObtenerPorSensorIdRangoFechas(sensorId,
                                                                            inicio,
                                                                            fin)
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


        [HttpGet("filtro-activos/{sensorId:int}")]
        public async Task<IActionResult> ObtenerActivos([FromRoute] int sensorId)
        {
            try
            {
                return Ok(new CustomResponse
                {
                    StatusCode = 200,
                    Message = "Lecturas por sensor obtenidas satisfactoriamente.",
                    Content = await _service.ObtenerActivasPorSensorId(sensorId)
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


        [HttpGet("estadisticas/{sensorId:int}")]
        public async Task<IActionResult> Estadisticas([FromRoute] int sensorId)
        {
            try
            {
                return Ok(new CustomResponse
                {
                    StatusCode = 200,
                    Message = "Estadísticas de lecturas por sensor obtenidas satisfactoriamente.",
                    Content = await _service.ObtenerEstadisticasPorSensorId(sensorId)
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
    }
}
