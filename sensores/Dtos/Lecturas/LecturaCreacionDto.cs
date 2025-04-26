using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace sensores.Dtos.Lecturas
{
    public class LecturaCreacionDto
    {
        [Required(ErrorMessage = "El campo sensor es obligatorio.")]
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "El campo sensor solo debe contener números.")]
        public int? SensorId { get; set; }

        [Required(ErrorMessage = "El campo valor es obligatorio.")]
        [RegularExpression(@"^-?[0-9]+(\.[0-9]{1,2})?$", ErrorMessage = "El campo valor solo debe contener números y puede tener hasta 2 decimales.")]
        public decimal? Valor { get; set; }

        [Required(ErrorMessage = "El campo estado es obligatorio.")]
        [RegularExpression(@"^[AIai]$", ErrorMessage = "El campo estado puede ser A (activo) o I (inactivo).")]
        public string? Estado { get; set; }
    }
}
