using sensores.Dtos.Sensores;
using sensores.Dtos.Ubicaciones;

namespace sensores.Services.UbicacionService
{
    public interface IUbicacionService
    {
        Task<List<UbicacionDto>> ObtenerTodos();
        Task<UbicacionDto> ObtenerPorId(int id);
        Task<UbicacionDto> Crear(UbicacionCreacionDto creacion);
        Task<UbicacionDto> Modificar(int id, UbicacionModificacionDto modificacion);
        Task Eliminar(int id);
    }
}
