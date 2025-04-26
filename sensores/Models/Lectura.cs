using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sensores.Models;

public partial class Lectura
{
    [Key]
    public int Id { get; set; }

    public int? SensorId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Valor { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? Estado { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Fecha { get; set; }

    [ForeignKey("SensorId")]
    [InverseProperty("Lecturas")]
    public virtual Sensore? Sensor { get; set; }
}
