using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sensores.Models;

public partial class SensoresContext : DbContext
{
    public SensoresContext()
    {
    }

    public SensoresContext(DbContextOptions<SensoresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lectura> Lecturas { get; set; }

    public virtual DbSet<Sensore> Sensores { get; set; }

    public virtual DbSet<Ubicacione> Ubicaciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESK-SASF-010\\KV;Initial Catalog=sensores;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lectura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lecturas__3214EC0799C136C4");

            entity.HasOne(d => d.Sensor).WithMany(p => p.Lecturas).HasConstraintName("lecturas_sensores_fk");
        });

        modelBuilder.Entity<Sensore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sensores__3214EC072EDA2B15");

            entity.HasOne(d => d.Ubicacion).WithMany(p => p.Sensores).HasConstraintName("sensores_ubicaciones_fk");
        });

        modelBuilder.Entity<Ubicacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ubicacio__3214EC077529F45C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
