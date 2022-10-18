﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20221006092321_Update-Doctor-Table")]
    partial class UpdateDoctorTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Entities.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(255)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(255)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Core.Entities.HospitalBed", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IDPatient")
                        .HasColumnType("int");

                    b.Property<int>("IDRoom")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("HospitalBeds");
                });

            modelBuilder.Entity("Core.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProductBrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductBrandId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Core.Entities.ProductBrand", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductBrands");
                });

            modelBuilder.Entity("Core.Entities.ProductType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("Core.Entities.Shift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdShift")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ShiftName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shift");
                });

            modelBuilder.Entity("Core.Entities.WorkShift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdDoctor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdShift")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ShiftId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("ShiftId");

                    b.ToTable("WorkShift");
                });

            modelBuilder.Entity("Core.Entity.MedicineBill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 10, 6, 16, 23, 20, 918, DateTimeKind.Local).AddTicks(11));

                    b.Property<Guid>("DoctorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("PayStatus")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("MedicineBill");
                });

            modelBuilder.Entity("Core.Entity.MedicineBillInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdMedicineInfo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MedicineBillID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MedicineInfomationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicineBillID");

                    b.HasIndex("MedicineInfomationId");

                    b.ToTable("MedicineBillInfo");
                });

            modelBuilder.Entity("Core.Entity.MedicineInfomation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ImportDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 10, 6, 9, 23, 20, 917, DateTimeKind.Utc).AddTicks(8342));

                    b.Property<bool>("IsEmpty")
                        .HasColumnType("bit");

                    b.Property<Guid>("MedicineIDType")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicineIDType");

                    b.ToTable("MedicineInfomation");
                });

            modelBuilder.Entity("Core.Entity.MedicineType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("MedicineType");
                });

            modelBuilder.Entity("Core.Entities.Product", b =>
                {
                    b.HasOne("Core.Entities.ProductBrand", "ProductBrand")
                        .WithMany()
                        .HasForeignKey("ProductBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductBrand");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("Core.Entities.WorkShift", b =>
                {
                    b.HasOne("Core.Entities.Doctor", "Doctor")
                        .WithMany("WorkShift")
                        .HasForeignKey("DoctorId");

                    b.HasOne("Core.Entities.Shift", "Shift")
                        .WithMany("WorkShift")
                        .HasForeignKey("ShiftId");

                    b.Navigation("Doctor");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("Core.Entity.MedicineBillInfo", b =>
                {
                    b.HasOne("Core.Entity.MedicineBill", "MedicineBills")
                        .WithMany("MedicineBillInfo")
                        .HasForeignKey("MedicineBillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entity.MedicineInfomation", "MedicineInfomation")
                        .WithMany("MedicineBillInfos")
                        .HasForeignKey("MedicineInfomationId");

                    b.Navigation("MedicineBills");

                    b.Navigation("MedicineInfomation");
                });

            modelBuilder.Entity("Core.Entity.MedicineInfomation", b =>
                {
                    b.HasOne("Core.Entity.MedicineType", "MedicineType")
                        .WithMany("MedicineInfomations")
                        .HasForeignKey("MedicineIDType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicineType");
                });

            modelBuilder.Entity("Core.Entities.Doctor", b =>
                {
                    b.Navigation("WorkShift");
                });

            modelBuilder.Entity("Core.Entities.Shift", b =>
                {
                    b.Navigation("WorkShift");
                });

            modelBuilder.Entity("Core.Entity.MedicineBill", b =>
                {
                    b.Navigation("MedicineBillInfo");
                });

            modelBuilder.Entity("Core.Entity.MedicineInfomation", b =>
                {
                    b.Navigation("MedicineBillInfos");
                });

            modelBuilder.Entity("Core.Entity.MedicineType", b =>
                {
                    b.Navigation("MedicineInfomations");
                });
#pragma warning restore 612, 618
        }
    }
}
