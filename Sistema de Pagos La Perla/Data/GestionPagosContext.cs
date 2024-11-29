using Microsoft.EntityFrameworkCore;
using Sistema_de_Pagos_La_Perla.Models;

namespace Sistema_de_Pagos_La_Perla.Data
{
    public class GestionPagosContext : DbContext
    {
        public GestionPagosContext(DbContextOptions<GestionPagosContext> options) : base(options) { }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Trabajador> Trabajadores { get; set; }
        public DbSet<Fundo> Fundos { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración Roles
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Roles");
                entity.HasKey(r => r.RolID);
                entity.Property(r => r.NombreRol).IsRequired().HasMaxLength(50);
            });

            // Configuración Trabajadores
            modelBuilder.Entity<Trabajador>(entity =>
            {
                entity.ToTable("Trabajadores");
                entity.HasKey(t => t.TrabajadorID);
                entity.Property(t => t.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(t => t.Rut).IsRequired().HasMaxLength(15).IsUnicode(false);
                entity.HasIndex(t => t.Rut).IsUnique();
                entity.Property(t => t.FechaRegistro).HasDefaultValueSql("GETDATE()");
                entity.Property(t => t.UsuarioRegistro).HasMaxLength(50);
                entity.Property(t => t.Estado).IsRequired();
            });

            // Configuración Fundos
            modelBuilder.Entity<Fundo>(entity =>
            {
                entity.ToTable("Fundos");
                entity.HasKey(f => f.FundoID);
                entity.Property(f => f.NombreFundo).IsRequired().HasMaxLength(50);
                entity.Property(f => f.Ubicacion).IsRequired().HasMaxLength(250);
                entity.Property(f => f.FechaRegistro).HasDefaultValueSql("GETDATE()");
                entity.HasMany(f => f.Asignaciones)
                      .WithOne(a => a.Fundo)
                      .HasForeignKey(a => a.FundoID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración Asignaciones
            modelBuilder.Entity<Asignacion>(entity =>
            {
                entity.ToTable("Asignaciones");
                entity.HasKey(a => a.AsignacionID);
                entity.Property(a => a.Tarea).IsRequired().HasMaxLength(200);
                entity.Property(a => a.Tarifa).IsRequired().HasColumnType("DECIMAL(10,2)");
                entity.Property(a => a.Turno).IsRequired().HasMaxLength(50);
                entity.Property(a => a.FechaRegistro).HasDefaultValueSql("GETDATE()");
                entity.HasOne(a => a.Fundo)
                      .WithMany(f => f.Asignaciones)
                      .HasForeignKey(a => a.FundoID);
            });

            // Configuración Asistencias
            modelBuilder.Entity<Asistencia>(entity =>
            {
                entity.ToTable("Asistencias");
                entity.HasKey(a => a.AsistenciaID);
                entity.Property(a => a.FechaAsistencia).IsRequired();
                entity.Property(a => a.UsuarioRegistro).HasMaxLength(50);
                entity.Property(a => a.Estado).IsRequired().HasMaxLength(10);
                entity.HasOne(a => a.Asignacion)
                      .WithMany(asig => asig.Asistencias)
                      .HasForeignKey(a => a.AsignacionID)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(a => a.Trabajador)
                      .WithMany(trab => trab.Asistencias)
                      .HasForeignKey(a => a.TrabajadorID)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
