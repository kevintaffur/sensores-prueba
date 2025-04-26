using Microsoft.EntityFrameworkCore;
using sensores.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace sensores.Dtos.Ubicaciones
{
    public class UbicacionCreacionDto
    {
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El campo nombre debe contener entre 3 y 20 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo estado es obligatorio.")]
        [RegularExpression(@"^[AIai]$", ErrorMessage = "El campo estado puede ser A (activo) o I (inactivo).")]
        public string Estado { get; set; }
    }
}
