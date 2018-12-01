using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UV_WEB3.Models
{
    public partial class uvContext : DbContext
    {
        private string connectionString;

        public uvContext(string _connectionString)
        {
            this.connectionString = _connectionString;
        }

        public uvContext(DbContextOptions<uvContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Datos> Datos { get; set; }
        public virtual DbSet<Equipos> Equipos { get; set; }
        public virtual DbSet<Estaciones> Estaciones { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<InformesUsuarios> InformesUsuarios { get; set; }
        public virtual DbSet<Registros> Registros { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        // Unable to generate entity type for table 'informes_registros'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Datos>(entity =>
            {
                entity.HasKey(e => e.IdDato);

                entity.ToTable("datos");

                entity.HasIndex(e => e.Estatus)
                    .HasName("ctDatos_estado_idx");

                entity.Property(e => e.IdDato)
                    .HasColumnName("Id_dato")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Estatus).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Observacion).HasColumnType("varchar(100)");

                entity.Property(e => e.UnidadMedida)
                    .IsRequired()
                    .HasColumnName("Unidad_medida")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.EstatusNavigation)
                    .WithMany(p => p.Datos)
                    .HasForeignKey(d => d.Estatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ctDatos_estado");
            });

            modelBuilder.Entity<Equipos>(entity =>
            {
                entity.HasKey(e => e.IdEquipo);

                entity.ToTable("equipos");

                entity.HasIndex(e => e.Estatus)
                    .HasName("ctEquipos_estado");

                entity.Property(e => e.IdEquipo)
                    .HasColumnName("Id_equipo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Estabilidad).HasColumnType("varchar(45)");

                entity.Property(e => e.Estatus).HasColumnType("int(11)");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.NoSerial)
                    .IsRequired()
                    .HasColumnName("No_serial")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Observacion).HasColumnType("varchar(100)");

                entity.Property(e => e.Presicion).HasColumnType("varchar(45)");

                entity.Property(e => e.Rango).HasColumnType("varchar(45)");

                entity.Property(e => e.Resolucion).HasColumnType("varchar(45)");

                entity.HasOne(d => d.EstatusNavigation)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.Estatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ctEquipos_estado");
            });

            modelBuilder.Entity<Estaciones>(entity =>
            {
                entity.HasKey(e => e.IdEstacion);

                entity.ToTable("estaciones");

                entity.HasIndex(e => e.Estatus)
                    .HasName("Id_estatus_idx");

                entity.Property(e => e.IdEstacion)
                    .HasColumnName("Id_estacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Estatus).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Observacion).HasColumnType("varchar(100)");

                entity.HasOne(d => d.EstatusNavigation)
                    .WithMany(p => p.Estaciones)
                    .HasForeignKey(d => d.Estatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ctEstaciones_dato");
            });

            modelBuilder.Entity<Estados>(entity =>
            {
                entity.HasKey(e => e.IdEstatus);

                entity.ToTable("estados");

                entity.Property(e => e.IdEstatus)
                    .HasColumnName("Id_estatus")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<InformesUsuarios>(entity =>
            {
                entity.HasKey(e => e.IdInformesUser);

                entity.ToTable("informes_usuarios");

                entity.HasIndex(e => e.Estatus)
                    .HasName("ctInformes_usuarios_estado");

                entity.Property(e => e.IdInformesUser)
                    .HasColumnName("idInformesUser")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Estatus).HasColumnType("int(11)");

                entity.Property(e => e.EstatusAnterior).HasColumnType("int(11)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Observacion).HasColumnType("varchar(100)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.EstatusNavigation)
                    .WithMany(p => p.InformesUsuarios)
                    .HasForeignKey(d => d.Estatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ctInformes_usuarios_estado");
            });

            modelBuilder.Entity<Registros>(entity =>
            {
                entity.HasKey(e => e.IdRegistro);

                entity.ToTable("registros");

                entity.HasIndex(e => e.Estatus)
                    .HasName("ctRegistros_estado");

                entity.HasIndex(e => e.IdDato)
                    .HasName("ctRegistros_dato");

                entity.HasIndex(e => e.IdEquipo)
                    .HasName("ctRegistros_equipo");

                entity.HasIndex(e => e.IdEstacion)
                    .HasName("ctRegistros_estacion");

                entity.Property(e => e.IdRegistro)
                    .HasColumnName("Id_registro")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Estatus).HasColumnType("int(11)");

                entity.Property(e => e.FechaLance)
                    .HasColumnName("Fecha_lance")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Hora).HasColumnType("varchar(45)");

                entity.Property(e => e.IdDato)
                    .HasColumnName("Id_dato")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEquipo)
                    .HasColumnName("Id_equipo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEstacion)
                    .HasColumnName("Id_estacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NoLance)
                    .HasColumnName("No_lance")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Observacion).HasColumnType("varchar(100)");

                entity.HasOne(d => d.EstatusNavigation)
                    .WithMany(p => p.Registros)
                    .HasForeignKey(d => d.Estatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ctRegistros_estado");

                entity.HasOne(d => d.IdDatoNavigation)
                    .WithMany(p => p.Registros)
                    .HasForeignKey(d => d.IdDato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ctRegistros_dato");

                entity.HasOne(d => d.IdEquipoNavigation)
                    .WithMany(p => p.Registros)
                    .HasForeignKey(d => d.IdEquipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ctRegistros_equipo");

                entity.HasOne(d => d.IdEstacionNavigation)
                    .WithMany(p => p.Registros)
                    .HasForeignKey(d => d.IdEstacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ctRegistros_estacion");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Estatus)
                    .HasName("ctUsuarios_estado");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("Id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApellidoPat)
                    .HasColumnName("Apellido_Pat")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.ApellitoMat)
                    .HasColumnName("Apellito_Mat")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Estatus).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Observacion).HasColumnType("varchar(100)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Usuario).HasColumnType("varchar(45)");

                entity.HasOne(d => d.EstatusNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Estatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ctUsuarios_estado");
            });
        }
    }
}
