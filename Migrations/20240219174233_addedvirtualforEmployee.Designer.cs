﻿// <auto-generated />
using EF_Core_WebApi.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_Core_WebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240219174233_addedvirtualforEmployee")]
    partial class addedvirtualforEmployee
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EF_Core_WebApi.Models.Departments", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("SubDepartment")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EF_Core_WebApi.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Address")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Area")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Contact")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Salary")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employeeinfo");
                });

            modelBuilder.Entity("EF_Core_WebApi.Models.Departments", b =>
                {
                    b.HasOne("EF_Core_WebApi.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
