using sensores.Dtos.Sensores;
using sensores.Models;

namespace sensores.Repositories.UbicacionRepository
{
    public interface IUbicacionRepository
    {
        Task<List<Ubicacione>> ObtenerTodos();
        Task<Ubicacione> ObtenerPorId(int id);
        Task<Ubicacione> Crear(Ubicacione entidad);
        Task<Ubicacione> Modificar(Ubicacione entidad);
    }
}
