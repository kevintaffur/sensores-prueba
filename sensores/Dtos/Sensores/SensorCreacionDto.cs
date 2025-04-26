using Microsoft.EntityFrameworkCore;
using sensores.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sensores.Dtos.Sensores
{
    public class SensorCreacionDto
    {
        [Required(ErrorMessage = "El campo ubicación es obligatorio.")]
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "El campo ubicación solo debe contener números.")]
        public int UbicacionId { get; set; }

        [Required(ErrorMessage = "El campo métrica es obligatorio.")]
        [RegularExpression(@"^(TEMPERATURA|HUMEDAD|PRESION|temperatura|humedad|presion|Temperatura|Humedad|Presion)$", ErrorMessage = "El campo métrica puede ser TEMPERATURA, HUMEDAD o PRESION.")]
        public string Metrica { get; set; }

        [Required(ErrorMessage = "El campo estado es obligatorio.")]
        [RegularExpression(@"^[AIai]$", ErrorMessage = "El campo estado puede ser A (activo) o I (inactivo).")]
        public string Estado { get; set; }
    }
}
