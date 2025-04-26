using System.ComponentModel.DataAnnotations;

namespace sensores.Dtos.Ubicaciones
{
    public class UbicacionModificacionDto
    {
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El campo nombre debe contener entre 3 y 20 caracteres.")]
        public string? Nombre { get; set; }

        [RegularExpression(@"^[AIai]$", ErrorMessage = "El campo estado puede ser A (activo) o I (inactivo).")]
        public string? Estado { get; set; }
    }
}
