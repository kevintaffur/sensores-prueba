using sensores.Models;

namespace sensores.Repositories.LecturaRepository
{
    public interface ILecturaRepository
    {
        Task<List<Lectura>> ObtenerTodos();
        Task<Lectura> ObtenerPorId(int id);
        Task<Lectura> Crear(Lectura entidad);
        Task<List<Lectura>> ObtenerPorSensorIdRangoFechas(int id, DateOnly inicio, DateOnly fin);
        Task<List<Lectura>> ObtenerActivasPorSensorId(int id);
        Task<decimal> ObtenerPromedioPorSensorId(int id);
        Task<decimal> ObtenerMinimoPorSensorId(int id);
        Task<decimal> ObtenerMaximoPorSensorId(int id);
    }
}
