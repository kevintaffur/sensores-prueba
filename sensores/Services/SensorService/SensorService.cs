using sensores.Dtos.Sensores;
using sensores.Dtos.Ubicaciones;
using sensores.Exceptions;
using sensores.Models;
using sensores.Repositories.SensorRepository;
using sensores.Repositories.UbicacionRepository;

namespace sensores.Services.SensorService
{
    public class SensorService : ISensorService
    {
        private readonly ISensorRepository _repository;
        private readonly IUbicacionRepository _ubicacionRepository;

        public SensorService(ISensorRepository repository,
                            IUbicacionRepository ubicacionRepository)
        {
            _repository = repository;
            _ubicacionRepository = ubicacionRepository;
        }

        public async Task<SensorDto> Crear(SensorCreacionDto creacion)
        {
            Ubicacione u = await _ubicacionRepository.ObtenerPorId(creacion.UbicacionId);

            if (u == null)
            {
                throw new CustomException("Ubicacion no existe");
            }

            Sensore nuevo = new()
            {
                Estado = creacion.Estado.ToUpper(),
                Metrica = creacion.Metrica.ToUpper(),
                UbicacionId = creacion.UbicacionId,
            };

            return MapearADto(await _repository.Crear(nuevo));
        }

        public async Task<SensorDto> Modificar(int id, SensorModificacionDto modificacion)
        {
            Sensore existente = await _repository.ObtenerPorId(id);
            if (existente == null)
            {
                throw new CustomException("Sensor no existe");
            }

            if (modificacion.UbicacionId != null)
            {
                Ubicacione u = await _ubicacionRepository.ObtenerPorId((int)modificacion.UbicacionId);
                if (u == null)
                {
                    throw new CustomException("Ubicacion no existe");
                }
                existente.UbicacionId = modificacion.UbicacionId;
            }
            if (modificacion.Metrica != null)
            {
                existente.Metrica = modificacion.Metrica.ToUpper();
            }
            if (modificacion.Estado != null)
            {
                existente.Estado = modificacion.Estado.ToUpper();
            }

            return MapearADto(await _repository.Modificar(existente));
        }

        public async Task<SensorDto> ObtenerPorId(int id)
        {
            Sensore existente = await _repository.ObtenerPorId(id);

            if (existente == null)
            {
                throw new CustomException("Sensor no existe");
            }

            return MapearADto(existente);
        }

        public async Task<List<SensorDto>> ObtenerTodos()
        {
            List<SensorDto> lista = new ();

            foreach (Sensore e in await _repository.ObtenerTodos())
            {
                lista.Add(MapearADto(e));
            }

            return lista;
        }

        public async Task Eliminar(int id)
        {
            Sensore existente = await _repository.ObtenerPorId(id);
            if (existente == null)
            {
                throw new CustomException("Sensor no existe");
            }
            existente.Estado = "N";
            await _repository.Modificar(existente);
        }

        private SensorDto MapearADto(Sensore entidad)
        {
            return new SensorDto()
            {
                Id = entidad.Id,
                Ubicacion = new UbicacionDto
                {
                    Id = entidad.Ubicacion.Id,
                    Nombre = entidad.Ubicacion.Nombre,
                    Estado = entidad.Ubicacion.Estado,
                },
                //UbicacionId = entidad.UbicacionId,
                Metrica = entidad.Metrica,
                Estado = entidad.Estado
            };
        }
    }
}
