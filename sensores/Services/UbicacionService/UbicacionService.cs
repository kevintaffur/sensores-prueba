using sensores.Dtos.Sensores;
using sensores.Dtos.Ubicaciones;
using sensores.Exceptions;
using sensores.Models;
using sensores.Repositories.SensorRepository;
using sensores.Repositories.UbicacionRepository;

namespace sensores.Services.UbicacionService
{
    public class UbicacionService : IUbicacionService
    {
        private readonly IUbicacionRepository _repository;
        private readonly ISensorRepository _sensorRepository;

        public UbicacionService(IUbicacionRepository repository,
                                ISensorRepository sensorRepository)
        {
            _repository = repository;
            _sensorRepository = sensorRepository;
        }

        public async Task<UbicacionDto> Crear(UbicacionCreacionDto creacion)
        {
            Ubicacione nuevo = new()
            {
                Nombre = creacion.Nombre,
                Estado = creacion.Estado.ToUpper()
            };

            return MapearADto(await _repository.Crear(nuevo));
        }

        public async Task<UbicacionDto> Modificar(int id, UbicacionModificacionDto modificacion)
        {
            Ubicacione existente = await _repository.ObtenerPorId(id);
            if (existente == null)
            {
                throw new CustomException("Ubicación no existe");
            }
            if (modificacion.Nombre != null)
            {
                existente.Nombre = modificacion.Nombre;
            }
            if (modificacion.Estado != null)
            {
                existente.Estado = modificacion.Estado.ToUpper();
            }

            return MapearADto(await _repository.Modificar(existente));
        }

        public async Task<UbicacionDto> ObtenerPorId(int id)
        {
            Ubicacione existente = await _repository.ObtenerPorId(id);

            if (existente == null)
            {
                throw new CustomException("Ubicación no existe.");
            }

            return MapearADto(existente);
        }

        public async Task<List<UbicacionDto>> ObtenerTodos()
        {
            List<UbicacionDto> lista = new();

            foreach (Ubicacione e in await _repository.ObtenerTodos())
            {
                lista.Add(MapearADto(e));
            }

            return lista;
        }

        public async Task Eliminar(int id)
        {
            Ubicacione existente = await _repository.ObtenerPorId(id);
            if (existente == null)
            {
                throw new CustomException("Ubicación no existe");
            }

            if (await _sensorRepository.ExisteSensorConUbicacion(id))
            {
                throw new CustomException("No se puede eliminar la ubicación porque tiene sensores asociados.");
            }

            existente.Estado = "N";
            await _repository.Modificar(existente);
        }

        private UbicacionDto MapearADto(Ubicacione entidad)
        {
            return new UbicacionDto()
            {
                Id = entidad.Id,
                Estado = entidad.Estado,
                Nombre = entidad.Nombre
            };
        }
    }
}
