using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sensores.Models;

public partial class Ubicacione
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? Estado { get; set; }

    [InverseProperty("Ubicacion")]
    public virtual ICollection<Sensore> Sensores { get; set; } = new List<Sensore>();
}
