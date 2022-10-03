using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entity;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

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
            modelBuilder.Entity<ProductBrand>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<ProductType>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<MedicineType>().HasKey(c => c.Id);
            modelBuilder.Entity<MedicineBill>().HasKey(c => c.Id);
            modelBuilder.Entity<MedicineInfomation>().HasKey(c => c.Id);
            modelBuilder.Entity<MedicineBillInfo>().HasKey(c => c.Id);
            modelBuilder.Entity<MedicineInfomation>().HasOne(a => a.MedicineType).WithMany(c => c.MedicineInfomations).HasForeignKey(d => d.IdType);
            modelBuilder.Entity<MedicineBillInfo>().HasOne(a => a.MedicineBills).WithMany(c => c.MedicineBillInfo).HasForeignKey(d => d.BillId);

            modelBuilder.Entity<Doctor>().HasKey(c => c.IdDoctor);
            modelBuilder.Entity<Shift>().HasKey(c => c.IdShift);
            modelBuilder.Entity<WorkShift>().HasKey(c => c.Id);
            modelBuilder.Entity<WorkShift>().HasOne(a => a.Shift).WithMany(c => c.WorkShift).HasForeignKey(d => d.IdShift);
            modelBuilder.Entity<WorkShift>().HasOne(d => d.Doctor).WithMany(f => f.WorkShift).HasForeignKey(g => g.IdDoctor);
        }
    }
}