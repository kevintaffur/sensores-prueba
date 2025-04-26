using sensores.Dtos.Sensores;

namespace sensores.Services.SensorService
{
    public interface ISensorService
    {
        Task<List<SensorDto>> ObtenerTodos();
        Task<SensorDto> ObtenerPorId(int id);
        Task<SensorDto> Crear(SensorCreacionDto creacion);
        Task<SensorDto> Modificar(int id, SensorModificacionDto modificacion);
        Task Eliminar(int id);
    }
}
