﻿// <auto-generated />
using System;
using Hospital.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hospital.DAL.Migrations
{
    [DbContext(typeof(HospitalDb))]
    [Migration("20221030111335_final")]
    partial class final
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hospital.DAL.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PerformanceRate")
                        .HasColumnType("int");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d4ec6c1b-ed19-4b10-a230-c0d0046b5389"),
                            Name = "Ahmed",
                            PerformanceRate = 90,
                            Salary = 30000.0,
                            Specialization = "Cardiology"
                        },
                        new
                        {
                            Id = new Guid("40caae98-b4db-46f4-80bb-4246e3776676"),
                            Name = "Nancy",
                            PerformanceRate = 80,
                            Salary = 40000.0,
                            Specialization = "Dermatology"
                        },
                        new
                        {
                            Id = new Guid("5222383e-020b-4097-8914-286553ef34b6"),
                            Name = "Wael",
                            PerformanceRate = 99,
                            Salary = 90000.0,
                            Specialization = "Dentist"
                        },
                        new
                        {
                            Id = new Guid("c70bbac3-2fec-46bc-95bc-9989d80f471b"),
                            Name = "MOhammed",
                            PerformanceRate = 80,
                            Salary = 95000.0,
                            Specialization = "opthomalogy"
                        },
                        new
                        {
                            Id = new Guid("8b68c8d4-4d97-4089-ad2e-7485d0d83861"),
                            Name = "Nader",
                            PerformanceRate = 100,
                            Salary = 75000.0,
                            Specialization = "Pediartics"
                        });
                });

            modelBuilder.Entity("Hospital.DAL.Issue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Issues");

                    b.HasData(
                        new
                        {
                            Id = new Guid("97398bac-ee33-456d-b150-b3d464a94ad6"),
                            Name = "Cold"
                        },
                        new
                        {
                            Id = new Guid("50e70766-3d34-4298-8dca-d2a6d574fedc"),
                            Name = "Stress"
                        },
                        new
                        {
                            Id = new Guid("05a73b2b-c16e-4b9f-adcf-2a61772196c0"),
                            Name = "Headache"
                        },
                        new
                        {
                            Id = new Guid("0cb2a78e-6823-4322-a8b4-a4ce0a16a511"),
                            Name = "Shawn"
                        },
                        new
                        {
                            Id = new Guid("fa453ef9-9b60-45f1-a8a6-b50a3f22fcbe"),
                            Name = "Michal"
                        },
                        new
                        {
                            Id = new Guid("918f8e6f-79b9-48f8-a137-172ffd22caa7"),
                            Name = "Arnold"
                        });
                });

            modelBuilder.Entity("Hospital.DAL.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("IssuePatient", b =>
                {
                    b.Property<Guid>("IssuesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("patientsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IssuesId", "patientsId");

                    b.HasIndex("patientsId");

                    b.ToTable("IssuePatient");
                });

            modelBuilder.Entity("IssuePatient", b =>
                {
                    b.HasOne("Hospital.DAL.Issue", null)
                        .WithMany()
                        .HasForeignKey("IssuesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.DAL.Patient", null)
                        .WithMany()
                        .HasForeignKey("patientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}