using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AvanceClaseOrdinaria.Models.dbModels;

public partial class BibliotecaContext : IdentityDbContext<AppUser, IdentityRole <int>, int>
{
    public BibliotecaContext()
    {
    }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cubiculo> Cubiculos { get; set; }

    public virtual DbSet<EstadoCubiculo> EstadoCubiculos { get; set; }

    public virtual DbSet<EstadoMesa> EstadoMesas { get; set; }

    public virtual DbSet<HistorialReservacione> HistorialReservaciones { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<PeriodoDeReserva> PeriodoDeReservas { get; set; }

    public virtual DbSet<ReservacionCubiculo> ReservacionCubiculos { get; set; }

    public virtual DbSet<ReservacionMesa> ReservacionMesas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Biblioteca;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cubiculo>(entity =>
        {
            entity.HasKey(e => e.CubiculoId).HasName("PK__Cubiculo__7607D64310D13264");

            entity.Property(e => e.CubiculoId).ValueGeneratedNever();

            entity.HasOne(d => d.Estado).WithMany(p => p.Cubiculos).HasConstraintName("FK__Cubiculos__Estad__48CFD27E");
        });

        modelBuilder.Entity<EstadoCubiculo>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PK__EstadoCu__FEF86B60ED059680");

            entity.Property(e => e.EstadoId).ValueGeneratedNever();
        });

        modelBuilder.Entity<EstadoMesa>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PK__EstadoMe__FEF86B60E9F9F970");

            entity.Property(e => e.EstadoId).ValueGeneratedNever();
        });

        modelBuilder.Entity<HistorialReservacione>(entity =>
        {
            entity.HasKey(e => e.HistorialId).HasName("PK__Historia__975206EF4B81424E");

            entity.Property(e => e.HistorialId).ValueGeneratedNever();

            entity.HasOne(d => d.ReservacionIdcubiculoNavigation).WithMany(p => p.HistorialReservaciones).HasConstraintName("FK_ReservacionCubiculo");

            entity.HasOne(d => d.ReservacionIdmesaNavigation).WithMany(p => p.HistorialReservaciones).HasConstraintName("FK_ReservacionMesa");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.MesaId).HasName("PK__Mesas__6A4196C89F9BE3C9");

            entity.Property(e => e.MesaId).ValueGeneratedNever();

            entity.HasOne(d => d.Estado).WithMany(p => p.Mesas).HasConstraintName("FK__Mesas__EstadoID__4BAC3F29");
        });

        modelBuilder.Entity<PeriodoDeReserva>(entity =>
        {
            entity.HasKey(e => e.PeriodoId).HasName("PK__PeriodoD__0ADD35CAEDCA6C25");

            entity.Property(e => e.PeriodoId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ReservacionCubiculo>(entity =>
        {
            entity.HasKey(e => e.ReservacionId).HasName("PK__Reservac__145B3EB54E3BA04A");

            entity.Property(e => e.ReservacionId).ValueGeneratedNever();

            entity.HasOne(d => d.Cubiculo).WithMany(p => p.ReservacionCubiculos).HasConstraintName("FK__Reservaci__Cubic__4CA06362");

            entity.HasOne(d => d.Periodo).WithMany(p => p.ReservacionCubiculos).HasConstraintName("FK__Reservaci__Perio__4D94879B");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ReservacionCubiculos).HasConstraintName("FK__Reservaci__Usuar__4E88ABD4");
        });

        modelBuilder.Entity<ReservacionMesa>(entity =>
        {
            entity.HasKey(e => e.ReservacionId).HasName("PK__Reservac__145B3EB5C2C2CEF6");

            entity.Property(e => e.ReservacionId).ValueGeneratedNever();

            entity.HasOne(d => d.Mesa).WithMany(p => p.ReservacionMesas).HasConstraintName("FK__Reservaci__MesaI__4F7CD00D");

            entity.HasOne(d => d.Periodo).WithMany(p => p.ReservacionMesas).HasConstraintName("FK__Reservaci__Perio__5070F446");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ReservacionMesas).HasConstraintName("FK__Reservaci__Usuar__5165187F");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302D183BDED1B");

            entity.Property(e => e.RolId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7989DAEDEEC");

            entity.Property(e => e.UsuarioId).ValueGeneratedNever();

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios).HasConstraintName("FK__Usuarios__RolID__52593CB8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
