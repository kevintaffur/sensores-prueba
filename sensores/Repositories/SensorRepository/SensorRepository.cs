using Microsoft.EntityFrameworkCore;
using sensores.Models;

namespace sensores.Repositories.SensorRepository
{
    public class SensorRepository : ISensorRepository
    {
        private readonly SensoresContext _context;

        public SensorRepository(SensoresContext context)
        {
            _context = context;
        }

        public async Task<Sensore> Crear(Sensore entidad)
        {
            await _context.Sensores.AddAsync(entidad);
            await _context.SaveChangesAsync();
            return entidad;
        }

        public async Task<Sensore> Modificar(Sensore entidad)
        {
            _context.Entry(entidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entidad;
        }

        public async Task<Sensore> ObtenerPorId(int id)
        {
            return await _context.Sensores
                .Include(s => s.Ubicacion)
                .FirstOrDefaultAsync(s => s.Id == id && !s.Estado.Equals("N"));
        }

        public async Task<List<Sensore>> ObtenerTodos()
        {
            return await _context.Sensores
                .Include(s => s.Ubicacion)
                .Where(s => !s.Estado.Equals("N"))
                .ToListAsync();
        }

        public async Task<bool> ExisteSensorConUbicacion(int id)
        {
            return await _context.Sensores
                .Include(s => s.Ubicacion)
                .AnyAsync(s => s.UbicacionId == id && !s.Estado.Equals("N"));
        }
    }
}
