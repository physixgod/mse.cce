﻿// <auto-generated />
using CCE.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CCE.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250128153844_b1")]
    partial class b1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CCE.Domain.Usine.Entities.Atelier", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsineCode")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Code");

                    b.HasIndex("UsineCode");

                    b.ToTable("Ateliers");
                });

            modelBuilder.Entity("CCE.Domain.Usine.Entities.Ligne", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Computer_Input")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Computer_Output")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Equation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecteurAtelierCode")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Code");

                    b.HasIndex("SecteurAtelierCode");

                    b.ToTable("Lignes");
                });

            modelBuilder.Entity("CCE.Domain.Usine.Entities.SecteurAtelier", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AtelierCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.HasIndex("AtelierCode");

                    b.ToTable("SecteurAteliers");
                });

            modelBuilder.Entity("CCE.Domain.Usine.Entities.TypePoste", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("TypePoste");
                });

            modelBuilder.Entity("CCE.Domain.Usine.Usine", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("Usines");
                });

            modelBuilder.Entity("CCE.Domain.Usine.Entities.Atelier", b =>
                {
                    b.HasOne("CCE.Domain.Usine.Usine", "Usine")
                        .WithMany("Ateliers")
                        .HasForeignKey("UsineCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Usine");
                });

            modelBuilder.Entity("CCE.Domain.Usine.Entities.Ligne", b =>
                {
                    b.HasOne("CCE.Domain.Usine.Entities.SecteurAtelier", "SecteurAtelier")
                        .WithMany("Lignes")
                        .HasForeignKey("SecteurAtelierCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("SecteurAtelier");
                });

            modelBuilder.Entity("CCE.Domain.Usine.Entities.SecteurAtelier", b =>
                {
                    b.HasOne("CCE.Domain.Usine.Entities.Atelier", "Atelier")
                        .WithMany("SecteurAteliers")
                        .HasForeignKey("AtelierCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Atelier");
                });

            modelBuilder.Entity("CCE.Domain.Usine.Entities.Atelier", b =>
                {
                    b.Navigation("SecteurAteliers");
                });

            modelBuilder.Entity("CCE.Domain.Usine.Entities.SecteurAtelier", b =>
                {
                    b.Navigation("Lignes");
                });

            modelBuilder.Entity("CCE.Domain.Usine.Usine", b =>
                {
                    b.Navigation("Ateliers");
                });
#pragma warning restore 612, 618
        }
    }
}
