﻿using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20221003103805_Test")]
    partial class Test
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
                b.Property<Guid>("IdDoctor")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Avatar")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Email")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("FullName")
                    .HasColumnType("nvarchar(max)");

                b.Property<Guid>("Id")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("PhoneNumber")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Position")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Sex")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Status")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("IdDoctor");

                b.ToTable("Doctor");
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
                b.Property<Guid>("IdShift")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid>("Id")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("ShiftName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Time")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("IdShift");

                b.ToTable("Shift");
            });

            modelBuilder.Entity("Core.Entities.WorkShift", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime?>("Date")
                    .HasColumnType("datetime2");

                b.Property<Guid>("IdDoctor")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid>("IdShift")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Status")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.HasIndex("IdDoctor");

                b.HasIndex("IdShift");

                b.ToTable("WorkShift");
            });

            modelBuilder.Entity("Core.Entity.MedicineBill", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("DateCreate")
                    .HasColumnType("datetime2");

                b.Property<Guid>("DoctorID")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid>("PatientID")
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

                b.Property<Guid>("BillId")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid>("IdMedicineInfo")
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

                b.HasIndex("BillId");

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

                b.Property<Guid>("IdType")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("ImportDate")
                    .HasColumnType("datetime2");

                b.Property<bool>("IsEmpty")
                    .HasColumnType("bit");

                b.Property<int>("Quantity")
                    .HasColumnType("int");

                b.Property<int>("UnitPrice")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("IdType");

                b.ToTable("MedicineInfomation");
            });

            modelBuilder.Entity("Core.Entity.MedicineType", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("Core.Entity.MedicineBillInfo", b =>
            {
                b.HasOne("Core.Entity.MedicineBill", "MedicineBills")
                    .WithMany("MedicineBillInfo")
                    .HasForeignKey("BillId")
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
                    .HasForeignKey("IdType")
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
