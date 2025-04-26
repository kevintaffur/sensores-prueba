using sensores.Models;

namespace sensores.Repositories.SensorRepository
{
    public interface ISensorRepository
    {
        Task<List<Sensore>> ObtenerTodos();
        Task<Sensore> ObtenerPorId(int id);
        Task<Sensore> Crear(Sensore entidad);
        Task<Sensore> Modificar(Sensore entidad);
        Task<bool> ExisteSensorConUbicacion(int id);
    }
}
