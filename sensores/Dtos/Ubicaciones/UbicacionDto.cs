using Microsoft.EntityFrameworkCore;
using sensores.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sensores.Dtos.Ubicaciones
{
    public class UbicacionDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Estado { get; set; }
    }
}
