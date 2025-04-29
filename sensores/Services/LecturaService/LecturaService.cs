using sensores.Dtos.Lecturas;
using sensores.Dtos.Sensores;
using sensores.Dtos.Ubicaciones;
using sensores.Exceptions;
using sensores.Models;
using sensores.Repositories.LecturaRepository;
using sensores.Repositories.SensorRepository;
using sensores.Repositories.UbicacionRepository;

namespace sensores.Services.LecturaService
{
    public class LecturaService : ILecturaService
    {
        private readonly ILecturaRepository _repository;
        private readonly ISensorRepository _sensorRepository;

        public LecturaService(ILecturaRepository repository,
                            ISensorRepository sensorRepository)
        {
            _repository = repository;
            _sensorRepository = sensorRepository;
        }

        public async Task<LecturaDto> Crear(LecturaCreacionDto creacion)
        {
            Lectura nuevo = new()
            {
                Fecha = DateTime.Now,
                Valor = creacion.Valor,
                SensorId = creacion.SensorId,
                Estado = creacion.Estado.ToUpper()
            };

            return MapearADto(await _repository.Crear(nuevo));
        }

        public async Task<LecturaDto> ObtenerPorId(int id)
        {
            Lectura existente = await _repository.ObtenerPorId(id);

            if (existente == null)
            {
                throw new CustomException("Lectura no existe");
            }

            return MapearADto(existente);
        }

        public async Task<List<LecturaDto>> ObtenerTodos()
        {
            List<LecturaDto> lista = new();

            foreach (Lectura e in await _repository.ObtenerTodos())
            {
                lista.Add(MapearADto(e));
            }

            return lista;
        }

        public async Task<List<LecturaDto>> ObtenerActivasPorSensorId(int id)
        {
            List<LecturaDto> lista = new();

            foreach (Lectura e in await _repository.ObtenerActivasPorSensorId(id))
            {
                lista.Add(MapearADto(e));
            }

            return lista;
        }


        public async Task<List<LecturaDto>> ObtenerPorSensorIdRangoFechas(int id, DateOnly inicio, DateOnly fin)
        {
            List<LecturaDto> lista = new();

            foreach (Lectura e in await _repository.ObtenerPorSensorIdRangoFechas(id, inicio, fin))
            {
                lista.Add(MapearADto(e));
            }

            return lista;
        }


        public async Task<EstadisticasDto> ObtenerEstadisticasPorSensorId(int id)
        {
            Sensore existente = await _sensorRepository.ObtenerPorId(id);
            if (existente == null)
            {
                throw new CustomException("Sensor no existe.");
            }

            return new EstadisticasDto
            {
                Promedio = await _repository.ObtenerPromedioPorSensorId(id),
                Maximo = await _repository.ObtenerMaximoPorSensorId(id),
                Minimo = await _repository.ObtenerMinimoPorSensorId(id)
            };
        }


        private LecturaDto MapearADto(Lectura entidad)
        {
            return new LecturaDto()
            {
                Id = entidad.Id,
                Estado = entidad.Estado,
                Sensor = new SensorDto
                {
                    Id = entidad.Sensor.Id,
                    Ubicacion = new UbicacionDto
                    {
                        Id = entidad.Sensor.Ubicacion.Id,
                        Nombre = entidad.Sensor.Ubicacion.Nombre,
                        Estado = entidad.Sensor.Ubicacion.Estado
                    },
                    Metrica = entidad.Sensor.Metrica,
                    Estado = entidad.Sensor.Estado
                },
                //SensorId = entidad.SensorId,
                Valor = entidad.Valor,
                Fecha = ((DateTime)entidad.Fecha).ToShortDateString() + " a las " + ((DateTime)entidad.Fecha).ToLongTimeString(),
            };
        }
    }
}
