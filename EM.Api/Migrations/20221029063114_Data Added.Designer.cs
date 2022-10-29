﻿// <auto-generated />
using System;
using EM.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EM.Api.Migrations
{
    [DbContext(typeof(EMContext))]
    [Migration("20221029063114_Data Added")]
    partial class DataAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EM.Api.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 10, 29, 9, 31, 14, 23, DateTimeKind.Local).AddTicks(2398),
                            Description = "This the Development team",
                            Name = "Development"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2022, 10, 29, 9, 31, 14, 25, DateTimeKind.Local).AddTicks(220),
                            Description = "This the Consulting team",
                            Name = "Consulting"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2022, 10, 29, 9, 31, 14, 25, DateTimeKind.Local).AddTicks(244),
                            Description = "This the Back Office team",
                            Name = "Back Office"
                        });
                });

            modelBuilder.Entity("EM.Api.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirtDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EM.Api.Models.EmployeeSkill", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("EmployeeSkills");
                });

            modelBuilder.Entity("EM.Api.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 10, 29, 9, 31, 14, 25, DateTimeKind.Local).AddTicks(7875),
                            Description = "Ability to communicate",
                            Name = "Communication"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2022, 10, 29, 9, 31, 14, 25, DateTimeKind.Local).AddTicks(8222),
                            Description = "Ability to work with team",
                            Name = "Teamwork"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2022, 10, 29, 9, 31, 14, 25, DateTimeKind.Local).AddTicks(8229),
                            Description = "Ability to solve problems",
                            Name = "Problem solving"
                        });
                });

            modelBuilder.Entity("EM.Api.Models.Employee", b =>
                {
                    b.HasOne("EM.Api.Models.Department", "Dapartment")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dapartment");
                });

            modelBuilder.Entity("EM.Api.Models.EmployeeSkill", b =>
                {
                    b.HasOne("EM.Api.Models.Employee", "Employee")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EM.Api.Models.Skill", "Skill")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("EM.Api.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("EM.Api.Models.Employee", b =>
                {
                    b.Navigation("EmployeeSkills");
                });

            modelBuilder.Entity("EM.Api.Models.Skill", b =>
                {
                    b.Navigation("EmployeeSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
