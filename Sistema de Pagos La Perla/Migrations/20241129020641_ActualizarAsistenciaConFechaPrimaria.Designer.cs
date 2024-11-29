﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sistema_de_Pagos_La_Perla.Data;

#nullable disable

namespace Sistema_de_Pagos_La_Perla.Migrations
{
    [DbContext(typeof(GestionPagosContext))]
    [Migration("20241129020641_ActualizarAsistenciaConFechaPrimaria")]
    partial class ActualizarAsistenciaConFechaPrimaria
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sistema_de_Pagos_La_Perla.Models.Asignacion", b =>
                {
                    b.Property<int>("AsignacionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AsignacionID"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<decimal?>("Descuento")
                        .HasColumnType("DECIMAL(10,2)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaAsignacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("FundoID")
                        .HasColumnType("int");

                    b.Property<string>("Tarea")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Tarifa")
                        .HasColumnType("DECIMAL(10,2)");

                    b.Property<string>("Turno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UsuarioRegistro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AsignacionID");

                    b.HasIndex("FundoID");

                    b.ToTable("Asignaciones", (string)null);
                });

            modelBuilder.Entity("Sistema_de_Pagos_La_Perla.Models.Asistencia", b =>
                {
                    b.Property<int>("AsistenciaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AsistenciaID"));

                    b.Property<int>("AsignacionID")
                        .HasColumnType("int");

                    b.Property<int?>("CantidadCompletada")
                        .HasColumnType("INT");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("FechaAsistencia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrabajadorID")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioRegistro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AsistenciaID");

                    b.HasIndex("AsignacionID");

                    b.HasIndex("TrabajadorID");

                    b.ToTable("Asistencias", (string)null);
                });

            modelBuilder.Entity("Sistema_de_Pagos_La_Perla.Models.Fundo", b =>
                {
                    b.Property<int>("FundoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FundoID"));

                    b.Property<string>("Contacto")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("NombreFundo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("FundoID");

                    b.ToTable("Fundos", (string)null);
                });

            modelBuilder.Entity("Sistema_de_Pagos_La_Perla.Models.Rol", b =>
                {
                    b.Property<int>("RolID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolID"));

                    b.Property<string>("NombreRol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RolID");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Sistema_de_Pagos_La_Perla.Models.Trabajador", b =>
                {
                    b.Property<int>("TrabajadorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrabajadorID"));

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("UsuarioRegistro")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TrabajadorID");

                    b.HasIndex("Rut")
                        .IsUnique();

                    b.ToTable("Trabajadores", (string)null);
                });

            modelBuilder.Entity("Sistema_de_Pagos_La_Perla.Models.Asignacion", b =>
                {
                    b.HasOne("Sistema_de_Pagos_La_Perla.Models.Fundo", "Fundo")
                        .WithMany("Asignaciones")
                        .HasForeignKey("FundoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Fundo");
                });

            modelBuilder.Entity("Sistema_de_Pagos_La_Perla.Models.Asistencia", b =>
                {
                    b.HasOne("Sistema_de_Pagos_La_Perla.Models.Asignacion", "Asignacion")
                        .WithMany("Asistencias")
                        .HasForeignKey("AsignacionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sistema_de_Pagos_La_Perla.Models.Trabajador", "Trabajador")
                        .WithMany("Asistencias")
                        .HasForeignKey("TrabajadorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Asignacion");

                    b.Navigation("Trabajador");
                });

            modelBuilder.Entity("Sistema_de_Pagos_La_Perla.Models.Asignacion", b =>
                {
                    b.Navigation("Asistencias");
                });

            modelBuilder.Entity("Sistema_de_Pagos_La_Perla.Models.Fundo", b =>
                {
                    b.Navigation("Asignaciones");
                });

            modelBuilder.Entity("Sistema_de_Pagos_La_Perla.Models.Trabajador", b =>
                {
                    b.Navigation("Asistencias");
                });
#pragma warning restore 612, 618
        }
    }
}
