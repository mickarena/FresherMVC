using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Core.Entity;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public DbSet<Nurse> Nurse { get; set; }

        public DbSet<Departments> Departments { get; set; }


        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<MedicineBill>? MedicineBill { get; set; }
        public DbSet<MedicineBillInfo>? MedicineBillInfo { get; set; }
        public DbSet<MedicineInfomation>? MedicineInfomation { get; set; }
        public DbSet<MedicineType>? MedicineType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<ProductBrand>().Property(p => p.Id).ValueGeneratedNever();
            //modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedNever();
            //modelBuilder.Entity<ProductType>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<Nurse>().HasKey(p => p.Id);
            modelBuilder.Entity<Departments>().HasKey(p => p.Id);
            modelBuilder.Entity<Nurse>()
         .HasOne(s => s.Departments)
         .WithMany(g => g.Nurses)
         .HasForeignKey(s => s.DepartmentId);
            modelBuilder.Entity<ProductBrand>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<ProductType>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<MedicineType>().HasKey(c => c.Id);
            modelBuilder.Entity<MedicineBill>().HasKey(c => c.Id);
            modelBuilder.Entity<MedicineInfomation>().HasKey(c => c.Id);
            modelBuilder.Entity<MedicineBillInfo>().HasKey(c => c.Id);
            modelBuilder.Entity<MedicineInfomation>().HasOne(a => a.MedicineType).WithMany(c => c.MedicineInfomations).HasForeignKey(d => d.IdType);
            modelBuilder.Entity<MedicineBillInfo>().HasOne(a => a.MedicineBills).WithMany(c => c.MedicineBillInfo).HasForeignKey(d => d.BillId);
        }
    }
}