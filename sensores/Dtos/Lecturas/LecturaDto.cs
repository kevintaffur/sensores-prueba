using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sensores.Dtos.Lecturas
{
    public class LecturaDto
    {
        public int Id { get; set; }
        public int? SensorId { get; set; }
        public decimal? Valor { get; set; }
        public string? Estado { get; set; }
        public string? Fecha { get; set; }
    }
}
