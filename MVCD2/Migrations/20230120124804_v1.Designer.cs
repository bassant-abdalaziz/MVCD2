﻿// <auto-generated />
using System;
using MVCD2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCD2.Migrations
{
    [DbContext(typeof(MVCITIDbContext))]
    [Migration("20230120124804_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVCD2.Models.Department", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("MVCD2.Models.DepartmentLocation", b =>
                {
                    b.Property<int>("DeptNumber")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DeptNumber", "Location");

                    b.ToTable("DepartmentLocation");
                });

            modelBuilder.Entity("MVCD2.Models.Dependent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<int>("ESSN")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relationship")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("ESSN");

                    b.ToTable("Dependents");
                });

            modelBuilder.Entity("MVCD2.Models.Employee", b =>
                {
                    b.Property<int>("SSN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SSN"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("money");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SuperVisorSSN")
                        .HasColumnType("int");

                    b.HasKey("SSN");

                    b.HasIndex("SuperVisorSSN");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MVCD2.Models.Project", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"));

                    b.Property<int>("DeptNum")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number");

                    b.HasIndex("DeptNum");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("MVCD2.Models.WorksOnProject", b =>
                {
                    b.Property<int>("ESSN")
                        .HasColumnType("int");

                    b.Property<int>("projectNum")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeesSSN")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.HasKey("ESSN", "projectNum");

                    b.HasIndex("EmployeesSSN");

                    b.HasIndex("projectNum");

                    b.ToTable("WorksOnProjects");
                });

            modelBuilder.Entity("MVCD2.Models.DepartmentLocation", b =>
                {
                    b.HasOne("MVCD2.Models.Department", "Department")
                        .WithMany("DepartmentLocations")
                        .HasForeignKey("DeptNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVCD2.Models.Dependent", b =>
                {
                    b.HasOne("MVCD2.Models.Employee", "Employee")
                        .WithMany("Dependents")
                        .HasForeignKey("ESSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("MVCD2.Models.Employee", b =>
                {
                    b.HasOne("MVCD2.Models.Employee", "SuperVisor")
                        .WithMany("Employees")
                        .HasForeignKey("SuperVisorSSN");

                    b.Navigation("SuperVisor");
                });

            modelBuilder.Entity("MVCD2.Models.Project", b =>
                {
                    b.HasOne("MVCD2.Models.Department", "Department")
                        .WithMany("Projects")
                        .HasForeignKey("DeptNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVCD2.Models.WorksOnProject", b =>
                {
                    b.HasOne("MVCD2.Models.Employee", "Employees")
                        .WithMany("WorksOnProjects")
                        .HasForeignKey("EmployeesSSN");

                    b.HasOne("MVCD2.Models.Project", "Project")
                        .WithMany("WorksOnProjects")
                        .HasForeignKey("projectNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("MVCD2.Models.Department", b =>
                {
                    b.Navigation("DepartmentLocations");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("MVCD2.Models.Employee", b =>
                {
                    b.Navigation("Dependents");

                    b.Navigation("Employees");

                    b.Navigation("WorksOnProjects");
                });

            modelBuilder.Entity("MVCD2.Models.Project", b =>
                {
                    b.Navigation("WorksOnProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
