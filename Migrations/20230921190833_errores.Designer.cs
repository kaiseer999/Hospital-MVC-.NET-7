﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bloodyvalentinee;

#nullable disable

namespace bloodyvalentinee.Migrations
{
    [DbContext(typeof(AplicacionDBContext))]
    [Migration("20230921190833_errores")]
    partial class errores
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("bloodyvalentinee.Models.Data.Dcorporales", b =>
                {
                    b.Property<int>("IdDcorporales")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDcorporales"));

                    b.Property<float>("Altura")
                        .HasColumnType("real");

                    b.Property<int>("FrecuenciaCardiaca")
                        .HasColumnType("int");

                    b.Property<int>("FrecuenciaRespiratoria")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<float>("Imc")
                        .HasColumnType("real");

                    b.Property<float>("PesoIdeal")
                        .HasColumnType("real");

                    b.Property<float>("PesoReal")
                        .HasColumnType("real");

                    b.Property<float>("Temperatura")
                        .HasColumnType("real");

                    b.HasKey("IdDcorporales");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("Dcorporale");
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.Diagnostico", b =>
                {
                    b.Property<int>("IdDiag")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDiag"));

                    b.Property<string>("ComentarioD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdDiag");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("Diagnostico");
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.EPS", b =>
                {
                    b.Property<int>("IdEps")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEps"));

                    b.Property<string>("NombreEps")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEps");

                    b.ToTable("EPS");
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.EnfermedadHereditaria", b =>
                {
                    b.Property<int>("IdEh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEh"));

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("NombreEh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioidUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdEh");

                    b.HasIndex("UsuarioidUsuario");

                    b.ToTable("EnfermedadHereditaria");
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.HistoriaClinica", b =>
                {
                    b.Property<int>("IdHcu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHcu"));

                    b.Property<int>("IdDcorporales")
                        .HasColumnType("int");

                    b.Property<int>("IdDiag")
                        .HasColumnType("int");

                    b.Property<int>("IdEh")
                        .HasColumnType("int");

                    b.Property<int>("IdIgeneral")
                        .HasColumnType("int");

                    b.Property<int>("IdMconsulta")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdHcu");

                    b.HasIndex("IdDcorporales")
                        .IsUnique();

                    b.HasIndex("IdDiag")
                        .IsUnique();

                    b.HasIndex("IdEh")
                        .IsUnique();

                    b.HasIndex("IdIgeneral")
                        .IsUnique();

                    b.HasIndex("IdMconsulta")
                        .IsUnique();

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("HistoriaClinica");
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.InsGeneral", b =>
                {
                    b.Property<int>("IdIgeneral")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdIgeneral"));

                    b.Property<int>("ComentarioIg")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdIgeneral");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("InsGeneral");
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.MotivoConsulta", b =>
                {
                    b.Property<int>("IdMconsulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMconsulta"));

                    b.Property<string>("ComentarioMc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdMconsulta");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("MotivoConsult");
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRol");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idUsuario"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EPSIdEps")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoCivil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNac")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ocupacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Religion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("idUsuario");

                    b.HasIndex("EPSIdEps");

                    b.HasIndex("RolId")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.Dcorporales", b =>
                {
                    b.HasOne("bloodyvalentinee.Models.Data.Usuario", "Usuario")
                        .WithOne("Dcorporales")
                        .HasForeignKey("bloodyvalentinee.Models.Data.Dcorporales", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.Diagnostico", b =>
                {
                    b.HasOne("bloodyvalentinee.Models.Data.Usuario", "Usuario")
                        .WithOne("Diagnostico")
                        .HasForeignKey("bloodyvalentinee.Models.Data.Diagnostico", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.EnfermedadHereditaria", b =>
                {
                    b.HasOne("bloodyvalentinee.Models.Data.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioidUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.HistoriaClinica", b =>
                {
                    b.HasOne("bloodyvalentinee.Models.Data.Dcorporales", "Dcorporales")
                        .WithOne("HistoriaClinica")
                        .HasForeignKey("bloodyvalentinee.Models.Data.HistoriaClinica", "IdDcorporales")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bloodyvalentinee.Models.Data.Diagnostico", "Diagnostico")
                        .WithOne("HistoriaClinica")
                        .HasForeignKey("bloodyvalentinee.Models.Data.HistoriaClinica", "IdDiag")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bloodyvalentinee.Models.Data.EnfermedadHereditaria", "EnfermedadHereditaria")
                        .WithOne("HistoriaClinica")
                        .HasForeignKey("bloodyvalentinee.Models.Data.HistoriaClinica", "IdEh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bloodyvalentinee.Models.Data.InsGeneral", "InsGeneral")
                        .WithOne("HistoriaClinica")
                        .HasForeignKey("bloodyvalentinee.Models.Data.HistoriaClinica", "IdIgeneral")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bloodyvalentinee.Models.Data.MotivoConsulta", "MotivoConsulta")
                        .WithOne("HistoriaClinica")
                        .HasForeignKey("bloodyvalentinee.Models.Data.HistoriaClinica", "IdMconsulta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bloodyvalentinee.Models.Data.Usuario", "Usuario")
                        .WithOne("HistoriaClinica")
                        .HasForeignKey("bloodyvalentinee.Models.Data.HistoriaClinica", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dcorporales");

                    b.Navigation("Diagnostico");

                    b.Navigation("EnfermedadHereditaria");

                    b.Navigation("InsGeneral");

                    b.Navigation("MotivoConsulta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.InsGeneral", b =>
                {
                    b.HasOne("bloodyvalentinee.Models.Data.Usuario", "Usuario")
                        .WithOne("InsGeneral")
                        .HasForeignKey("bloodyvalentinee.Models.Data.InsGeneral", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.MotivoConsulta", b =>
                {
                    b.HasOne("bloodyvalentinee.Models.Data.Usuario", "Usuario")
                        .WithOne("MotivoConsulta")
                        .HasForeignKey("bloodyvalentinee.Models.Data.MotivoConsulta", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.Usuario", b =>
                {
                    b.HasOne("bloodyvalentinee.Models.Data.EPS", "EPS")
                        .WithMany()
                        .HasForeignKey("EPSIdEps")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bloodyvalentinee.Models.Data.Rol", "Rol")
                        .WithOne()
                        .HasForeignKey("bloodyvalentinee.Models.Data.Usuario", "RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EPS");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.Dcorporales", b =>
                {
                    b.Navigation("HistoriaClinica")
                        .IsRequired();
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.Diagnostico", b =>
                {
                    b.Navigation("HistoriaClinica")
                        .IsRequired();
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.EnfermedadHereditaria", b =>
                {
                    b.Navigation("HistoriaClinica")
                        .IsRequired();
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.InsGeneral", b =>
                {
                    b.Navigation("HistoriaClinica")
                        .IsRequired();
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.MotivoConsulta", b =>
                {
                    b.Navigation("HistoriaClinica")
                        .IsRequired();
                });

            modelBuilder.Entity("bloodyvalentinee.Models.Data.Usuario", b =>
                {
                    b.Navigation("Dcorporales")
                        .IsRequired();

                    b.Navigation("Diagnostico")
                        .IsRequired();

                    b.Navigation("HistoriaClinica")
                        .IsRequired();

                    b.Navigation("InsGeneral")
                        .IsRequired();

                    b.Navigation("MotivoConsulta")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
