using Microsoft.EntityFrameworkCore;
using sensores.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sensores.Dtos.Sensores
{
    public class SensorDto
    {
        public int Id { get; set; }
        public int? UbicacionId { get; set; }
        public string? Metrica { get; set; }
        public string? Estado { get; set; }
    }
}
