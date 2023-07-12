﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(CitasCampusContext))]
    partial class CitasCampusContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Acudiente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("acu_codigo");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("acu_direccion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("acu_nombreCompleto");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("acu_telefono");

                    b.HasKey("Id");

                    b.ToTable("acudiente", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cit_codigo");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int")
                        .HasColumnName("cit_estadoCita");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date")
                        .HasColumnName("cit_fecha");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int")
                        .HasColumnName("cit_medico");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("cit_datosUsuario");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.HasIndex("MedicoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("cita", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Consultorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cons_id");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("cons_nombre");

                    b.HasKey("Id");

                    b.ToTable("consultorio", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Especialidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("esp_id");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("esp_nombre");

                    b.HasKey("Id");

                    b.ToTable("especialidad", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("estcita_id");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("estcita_nombre");

                    b.HasKey("Id");

                    b.ToTable("estado_cita", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("gen_id");

                    b.Property<string>("Abreviatura")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("gen_abreviatura");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("gen_nombre");

                    b.HasKey("Id");

                    b.ToTable("genero", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("med_nroMatriculaProfecional");

                    b.Property<int?>("ConsultorioId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("med_consultorio");

                    b.Property<int?>("EspecialidadId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("med_especialidad");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)")
                        .HasColumnName("med_nombreCompleto");

                    b.HasKey("Id");

                    b.HasIndex("ConsultorioId");

                    b.HasIndex("EspecialidadId");

                    b.ToTable("medicos", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("tipdoc_id");

                    b.Property<string>("Abreviatura")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("tipdoc_abreviatura");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("tipdoc_nombre");

                    b.HasKey("Id");

                    b.ToTable("tipo_documento", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("usu_id");

                    b.Property<int?>("AcudienteId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("usu_acudiente");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("usu_direccion");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("usu_e-mail");

                    b.Property<int?>("GeneroId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("usu_genero");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("usu_primer_apellido");

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("usu_nombre");

                    b.Property<string>("SegundoApellido")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("usu_segdo_apellido");

                    b.Property<string>("SegundoNombre")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("usu_segdo_nombre");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("usu_telefono");

                    b.Property<int?>("TipoDocumentoId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("usu_tipdoc");

                    b.HasKey("Id");

                    b.HasIndex("AcudienteId");

                    b.HasIndex("GeneroId");

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Cita", b =>
                {
                    b.HasOne("Core.Entities.Estado", "Estado")
                        .WithMany("Citas")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Medico", "Medico")
                        .WithMany("Citas")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Usuario", "Usuario")
                        .WithMany("Citas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");

                    b.Navigation("Medico");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Core.Entities.Medico", b =>
                {
                    b.HasOne("Core.Entities.Consultorio", "Consultorio")
                        .WithMany("Medicos")
                        .HasForeignKey("ConsultorioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Especialidad", "Especialidad")
                        .WithMany("Medicos")
                        .HasForeignKey("EspecialidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consultorio");

                    b.Navigation("Especialidad");
                });

            modelBuilder.Entity("Core.Entities.Usuario", b =>
                {
                    b.HasOne("Core.Entities.Acudiente", "Acudiente")
                        .WithMany("Usuarios")
                        .HasForeignKey("AcudienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Genero", "Genero")
                        .WithMany("Usuarios")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoDocumento", "TipoDocumento")
                        .WithMany("Usuarios")
                        .HasForeignKey("TipoDocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acudiente");

                    b.Navigation("Genero");

                    b.Navigation("TipoDocumento");
                });

            modelBuilder.Entity("Core.Entities.Acudiente", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Core.Entities.Consultorio", b =>
                {
                    b.Navigation("Medicos");
                });

            modelBuilder.Entity("Core.Entities.Especialidad", b =>
                {
                    b.Navigation("Medicos");
                });

            modelBuilder.Entity("Core.Entities.Estado", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("Core.Entities.Genero", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Core.Entities.Medico", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("Core.Entities.TipoDocumento", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Core.Entities.Usuario", b =>
                {
                    b.Navigation("Citas");
                });
#pragma warning restore 612, 618
        }
    }
}
