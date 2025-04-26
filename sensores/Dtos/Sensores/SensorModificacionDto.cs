using System.ComponentModel.DataAnnotations;

namespace sensores.Dtos.Sensores
{
    public class SensorModificacionDto
    {
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "El campo ubicación solo debe contener números.")]
        public int? UbicacionId { get; set; }

        [RegularExpression(@"^(TEMPERATURA|HUMEDAD|PRESION|temperatura|humedad|presion|Temperatura|Humedad|Presion)$", ErrorMessage = "El campo métrica puede ser TEMPERATURA, HUMEDAD o PRESION.")]
        public string? Metrica { get; set; }

        [RegularExpression(@"^[AIai]$", ErrorMessage = "El campo estado puede ser A (activo) o I (inactivo).")]
        public string? Estado { get; set; }
    }
}
