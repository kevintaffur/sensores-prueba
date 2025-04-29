using Microsoft.EntityFrameworkCore;
using sensores.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using sensores.Dtos.Ubicaciones;

namespace sensores.Dtos.Sensores
{
    public class SensorDto
    {
        public int Id { get; set; }
        public UbicacionDto Ubicacion { get; set; }
        //public int? UbicacionId { get; set; }
        public string? Metrica { get; set; }
        public string? Estado { get; set; }
    }
}
