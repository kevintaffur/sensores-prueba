using Microsoft.EntityFrameworkCore;
using sensores.Models;

namespace sensores.Repositories.LecturaRepository
{
    public class LecturaRepository : ILecturaRepository
    {
        private readonly SensoresContext _context;

        public LecturaRepository(SensoresContext context)
        {
            _context = context;
        }

        public async Task<Lectura> Crear(Lectura entidad)
        {
            await _context.Lecturas.AddAsync(entidad);
            await _context.SaveChangesAsync();
            return entidad;
        }

        public async Task<Lectura> ObtenerPorId(int id)
        {
            return await _context.Lecturas
                .FirstOrDefaultAsync(s => s.Id == id && !s.Estado.Equals("N"));
        }

        public async Task<List<Lectura>> ObtenerTodos()
        {
            return await _context.Lecturas
                .Where(s => !s.Estado.Equals("N"))
                .ToListAsync();
        }

        public async Task<List<Lectura>> ObtenerPorSensorIdRangoFechas(int id, DateOnly inicio, DateOnly fin)
        {
            return await _context.Lecturas
                .Where(s => s.SensorId == id &&
                    ((inicio == default || fin == default) || DateOnly.FromDateTime((DateTime)s.Fecha) >= inicio && DateOnly.FromDateTime((DateTime)s.Fecha) <= fin) &&
                    !s.Estado.Equals("N"))
                .ToListAsync();
        }

        public async Task<List<Lectura>> ObtenerActivasPorSensorId(int id)
        {
            return await _context.Lecturas
                .Where(s => s.Estado.Equals("A") && s.SensorId == id)
                .ToListAsync();
        }

        public async Task<decimal> ObtenerPromedioPorSensorId(int id)
        {
            decimal valor = await _context.Lecturas
                .Where(s => s.SensorId == id && !s.Estado.Equals("N"))
                .AverageAsync(s => s.Valor) ?? 0;

            return Math.Round(valor, 2);
        }

        public async Task<decimal> ObtenerMinimoPorSensorId(int id)
        {
            decimal valor = await _context.Lecturas
                .Where(s => s.SensorId == id && !s.Estado.Equals("N"))
                .MinAsync(s => s.Valor) ?? 0;

            return Math.Round(valor, 2);
        }

        public async Task<decimal> ObtenerMaximoPorSensorId(int id)
        {
            decimal valor = await _context.Lecturas
                .Where(s => s.SensorId == id && !s.Estado.Equals("N"))
                .MaxAsync(s => s.Valor) ?? 0;

            return Math.Round(valor, 2);
        }
    }
}
