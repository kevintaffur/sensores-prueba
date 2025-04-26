using Microsoft.EntityFrameworkCore;
using sensores.Models;

namespace sensores.Repositories.UbicacionRepository
{
    public class UbicacionRepository : IUbicacionRepository
    {
        private readonly SensoresContext _context;

        public UbicacionRepository(SensoresContext context)
        {
            _context = context;
        }

        public async Task<Ubicacione> Crear(Ubicacione entidad)
        {
            await _context.Ubicaciones.AddAsync(entidad);
            await _context.SaveChangesAsync();
            return entidad;
        }

        public async Task<Ubicacione> Modificar(Ubicacione entidad)
        {
            _context.Entry(entidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entidad;
        }

        public async Task<Ubicacione> ObtenerPorId(int id)
        {
            return await _context.Ubicaciones
                .FirstOrDefaultAsync(s => s.Id == id && !s.Estado.Equals("N"));
        }

        public async Task<List<Ubicacione>> ObtenerTodos()
        {
            return await _context.Ubicaciones
                .Where(s => !s.Estado.Equals("N"))
                .ToListAsync();
        }
    }
}
