using sensores.Dtos.Lecturas;
using sensores.Models;

namespace sensores.Services.LecturaService
{
    public interface ILecturaService
    {
        Task<List<LecturaDto>> ObtenerTodos();
        Task<LecturaDto> ObtenerPorId(int id);
        Task<LecturaDto> Crear(LecturaCreacionDto creacion);
        Task<List<LecturaDto>> ObtenerPorSensorIdRangoFechas(int id, DateOnly inicio, DateOnly fin);
        Task<List<LecturaDto>> ObtenerActivasPorSensorId(int id);
        Task<EstadisticasDto> ObtenerEstadisticasPorSensorId(int id);
    }
}
