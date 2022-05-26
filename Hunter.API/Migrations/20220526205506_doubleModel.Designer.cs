﻿// <auto-generated />
using System;
using Hunter.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hunter.API.Migrations
{
    [DbContext(typeof(HunterDbContext))]
    [Migration("20220526205506_doubleModel")]
    partial class doubleModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hunter.API.Data.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Billing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Billing = "free unlimited",
                            Name = "Solution Hunter Engineering",
                            Region = "NewEngland"
                        });
                });

            modelBuilder.Entity("Hunter.API.Data.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("IndividualId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IndividualId");

                    b.ToTable("Features");

                    b.HasData(
                        new
                        {
                            Id = 1
                        });
                });

            modelBuilder.Entity("Hunter.API.Data.Ghost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Era")
                        .HasColumnType("int");

                    b.Property<int>("PopulationId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("initialEra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Ghosts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Era = 0,
                            PopulationId = 0,
                            ProjectId = 1,
                            initialEra = "",
                            isActive = true
                        });
                });

            modelBuilder.Entity("Hunter.API.Data.Individual", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("PopulationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PopulationId");

                    b.ToTable("Individuals");

                    b.HasData(
                        new
                        {
                            Id = 1
                        });
                });

            modelBuilder.Entity("Hunter.API.Data.Population", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Evolution")
                        .HasColumnType("int");

                    b.Property<int?>("GhostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GhostId")
                        .IsUnique()
                        .HasFilter("[GhostId] IS NOT NULL");

                    b.ToTable("Populations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Evolution = 0
                        });
                });

            modelBuilder.Entity("Hunter.API.Data.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Runner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            Designer = "Chuck Duncan",
                            Runner = "Buttons Duncan",
                            Title = "Sample Project"
                        });
                });

            modelBuilder.Entity("Hunter.API.Data.Feature", b =>
                {
                    b.HasOne("Hunter.API.Data.Individual", "Individual")
                        .WithMany("Features")
                        .HasForeignKey("IndividualId");

                    b.Navigation("Individual");
                });

            modelBuilder.Entity("Hunter.API.Data.Ghost", b =>
                {
                    b.HasOne("Hunter.API.Data.Project", "Project")
                        .WithMany("Ghosts")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Hunter.API.Data.Individual", b =>
                {
                    b.HasOne("Hunter.API.Data.Population", "Population")
                        .WithMany("Individuals")
                        .HasForeignKey("PopulationId");

                    b.Navigation("Population");
                });

            modelBuilder.Entity("Hunter.API.Data.Population", b =>
                {
                    b.HasOne("Hunter.API.Data.Ghost", "Ghost")
                        .WithOne("Population")
                        .HasForeignKey("Hunter.API.Data.Population", "GhostId");

                    b.Navigation("Ghost");
                });

            modelBuilder.Entity("Hunter.API.Data.Project", b =>
                {
                    b.HasOne("Hunter.API.Data.Company", "Company")
                        .WithMany("Projects")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Hunter.API.Data.Company", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Hunter.API.Data.Ghost", b =>
                {
                    b.Navigation("Population");
                });

            modelBuilder.Entity("Hunter.API.Data.Individual", b =>
                {
                    b.Navigation("Features");
                });

            modelBuilder.Entity("Hunter.API.Data.Population", b =>
                {
                    b.Navigation("Individuals");
                });

            modelBuilder.Entity("Hunter.API.Data.Project", b =>
                {
                    b.Navigation("Ghosts");
                });
#pragma warning restore 612, 618
        }
    }
}
