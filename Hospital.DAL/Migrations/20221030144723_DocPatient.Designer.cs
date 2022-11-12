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
    [Migration("20221030144723_DocPatient")]
    partial class DocPatient
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
                            Id = new Guid("8f39d552-dcf1-4ab2-b2df-c9704620ce65"),
                            Name = "Ahmed",
                            PerformanceRate = 90,
                            Salary = 30000.0,
                            Specialization = "Cardiology"
                        },
                        new
                        {
                            Id = new Guid("f5fdacad-1e82-4974-ab0d-184acb7f1460"),
                            Name = "Nancy",
                            PerformanceRate = 80,
                            Salary = 40000.0,
                            Specialization = "Dermatology"
                        },
                        new
                        {
                            Id = new Guid("78a29580-f456-445c-88be-a918f17b1994"),
                            Name = "Wael",
                            PerformanceRate = 99,
                            Salary = 90000.0,
                            Specialization = "Dentist"
                        },
                        new
                        {
                            Id = new Guid("b21a2b61-0e8b-4c4f-9b7b-1f887f1dbeee"),
                            Name = "MOhammed",
                            PerformanceRate = 80,
                            Salary = 95000.0,
                            Specialization = "opthomalogy"
                        },
                        new
                        {
                            Id = new Guid("e037fcfb-faf8-4e9d-a336-660de3b2e10f"),
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
                            Id = new Guid("a9229472-e62f-4991-842a-8d2cc3b849a5"),
                            Name = "Cold"
                        },
                        new
                        {
                            Id = new Guid("ba1e0658-1624-4c10-ba98-e3b60bafe52d"),
                            Name = "Stress"
                        },
                        new
                        {
                            Id = new Guid("01c92841-985d-44ea-8a5a-fbc10d4e6ca1"),
                            Name = "Headache"
                        });
                });

            modelBuilder.Entity("Hospital.DAL.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Doc_Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("doctorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("doctorId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("136dd994-5616-419f-9f16-b538c42c63b7"),
                            Doc_Id = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "Shawn"
                        },
                        new
                        {
                            Id = new Guid("0665d558-fdd1-4f53-bc3c-18fcfbee8fd2"),
                            Doc_Id = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "Michal"
                        },
                        new
                        {
                            Id = new Guid("aa84338d-d741-44d6-bbea-f5de82225344"),
                            Doc_Id = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "Arnold"
                        });
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

            modelBuilder.Entity("Hospital.DAL.Patient", b =>
                {
                    b.HasOne("Hospital.DAL.Doctor", "doctor")
                        .WithMany("Patients")
                        .HasForeignKey("doctorId");

                    b.Navigation("doctor");
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

            modelBuilder.Entity("Hospital.DAL.Doctor", b =>
                {
                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
