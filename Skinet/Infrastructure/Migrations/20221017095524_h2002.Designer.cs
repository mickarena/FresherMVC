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
    [Migration("20221017095524_h2002")]
    partial class h2002
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
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Core.Entities.HospitalBed", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IDPatient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IDRoom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("HospitalBeds");
                });

            modelBuilder.Entity("Core.Entities.MedicineBill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 10, 17, 16, 55, 24, 66, DateTimeKind.Local).AddTicks(3393));

                    b.Property<Guid>("DoctorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("PayStatus")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("MedicineBills");
                });

            modelBuilder.Entity("Core.Entities.MedicineBillInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdMedicineInfo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MedicineBillID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMedicineInfo");

                    b.HasIndex("MedicineBillID");

                    b.ToTable("MedicineBillInfos");
                });

            modelBuilder.Entity("Core.Entities.MedicineInfomation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ImportDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 10, 17, 9, 55, 24, 66, DateTimeKind.Utc).AddTicks(2204));

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

                    b.ToTable("MedicineInfomations");
                });

            modelBuilder.Entity("Core.Entities.MedicineType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("MedicineTypes");
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

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("VARCHAR(5)");

                    b.Property<string>("ShiftName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR(30)");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("VARCHAR(5)");

                    b.HasKey("Id");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("Core.Entities.WorkShift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 10, 17, 16, 55, 24, 66, DateTimeKind.Local).AddTicks(9901));

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdDoctor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdShift")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdShift");

                    b.ToTable("WorkShifts");
                });

            modelBuilder.Entity("Core.Entities.MedicineBillInfo", b =>
                {
                    b.HasOne("Core.Entities.MedicineInfomation", "MedicineInfomations")
                        .WithMany("MedicineBillInfos")
                        .HasForeignKey("IdMedicineInfo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.MedicineBill", "MedicineBills")
                        .WithMany("MedicineBillInfos")
                        .HasForeignKey("MedicineBillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicineBills");

                    b.Navigation("MedicineInfomations");
                });

            modelBuilder.Entity("Core.Entities.MedicineInfomation", b =>
                {
                    b.HasOne("Core.Entities.MedicineType", "MedicineTypes")
                        .WithMany("MedicineInfomations")
                        .HasForeignKey("MedicineIDType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicineTypes");
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
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Shift", "Shift")
                        .WithMany("WorkShift")
                        .HasForeignKey("IdShift")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("Core.Entities.Doctor", b =>
                {
                    b.Navigation("WorkShift");
                });

            modelBuilder.Entity("Core.Entities.MedicineBill", b =>
                {
                    b.Navigation("MedicineBillInfos");
                });

            modelBuilder.Entity("Core.Entities.MedicineInfomation", b =>
                {
                    b.Navigation("MedicineBillInfos");
                });

            modelBuilder.Entity("Core.Entities.MedicineType", b =>
                {
                    b.Navigation("MedicineInfomations");
                });

            modelBuilder.Entity("Core.Entities.Shift", b =>
                {
                    b.Navigation("WorkShift");
                });
#pragma warning restore 612, 618
        }
    }
}
