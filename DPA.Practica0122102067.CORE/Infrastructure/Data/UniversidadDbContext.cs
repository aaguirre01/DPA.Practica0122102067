using System;
using System.Collections.Generic;
using DPA.Practica0122102067.CORE.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DPA.Practica0122102067.CORE.Infrastructure.Data;

public partial class UniversidadDbContext : DbContext
{
    public UniversidadDbContext()
    {
    }

    public UniversidadDbContext(DbContextOptions<UniversidadDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<Estudiante> Estudiante { get; set; }
    public object Estudiantes { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=UniversidadDB;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carrera__3214EC07B2A701B5");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estudian__3214EC07C70D8201");

            entity.HasIndex(e => e.Correo, "UQ__Estudian__60695A1910FBF99F").IsUnique();

            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Materno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Paterno)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Carrera).WithMany(p => p.Estudiante)
                .HasForeignKey(d => d.CarreraId)
                .HasConstraintName("FK_Estudiante_Carrera");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
