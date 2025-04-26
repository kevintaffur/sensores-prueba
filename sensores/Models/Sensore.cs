using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sensores.Models;

public partial class Sensore
{
    [Key]
    public int Id { get; set; }

    public int? UbicacionId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Metrica { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? Estado { get; set; }

    [InverseProperty("Sensor")]
    public virtual ICollection<Lectura> Lecturas { get; set; } = new List<Lectura>();

    [ForeignKey("UbicacionId")]
    [InverseProperty("Sensores")]
    public virtual Ubicacione? Ubicacion { get; set; }
}
