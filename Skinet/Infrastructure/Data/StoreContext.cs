using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<ProductBrand>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<ProductType>().Property(p => p.Id).ValueGeneratedNever();
            //modelBuilder.Entity<MedicineType>().HasKey(c => c.Id);
            //modelBuilder.Entity<MedicineBill>().HasKey(c => c.Id);
            //modelBuilder.Entity<MedicineInfomation>().HasKey(c => c.Id);
            //modelBuilder.Entity<MedicineBillInfo>().HasKey(c => c.Id);
            //modelBuilder.Entity<MedicineInfomation>().HasOne(a => a.MedicineType).WithMany(c => c.MedicineInfomations).HasForeignKey(d => d.MedicineIDType);
            //modelBuilder.Entity<MedicineBillInfo>().HasOne(a => a.MedicineBills).WithMany(c => c.MedicineBillInfo).HasForeignKey(d => d.MedicineBillID);

            ////Thuộc tính của model edit từ đây
            //modelBuilder.Entity<MedicineInfomation>().Property(c => c.MedicineIDType).IsRequired();
            //modelBuilder.Entity<MedicineInfomation>().Property(c => c.IsEmpty).IsRequired();
            //modelBuilder.Entity<MedicineInfomation>().Property(c => c.ImportDate).IsRequired();
            //modelBuilder.Entity<MedicineInfomation>().Property(c => c.ImportDate).HasDefaultValue(DateTime.UtcNow);
            //modelBuilder.Entity<MedicineInfomation>().Property(c => c.ExpireDate).IsRequired();
            //modelBuilder.Entity<MedicineInfomation>().Property(c => c.Quantity).IsRequired();
            //modelBuilder.Entity<MedicineInfomation>().Property(c => c.UnitPrice).IsRequired();
            //modelBuilder.Entity<MedicineInfomation>().Property(c => c.Name).IsRequired();
            //modelBuilder.Entity<MedicineInfomation>().Property(c => c.Name).HasMaxLength(100);
            //modelBuilder.Entity<MedicineInfomation>().Property(c => c.Quantity).HasDefaultValue(1);

            //modelBuilder.Entity<MedicineType>().Property(c => c.Name).IsRequired();
            //modelBuilder.Entity<MedicineType>().Property(c => c.Name).HasMaxLength(100);

            //modelBuilder.Entity<MedicineBill>().Property(c => c.DoctorID).IsRequired();
            //modelBuilder.Entity<MedicineBill>().Property(c => c.DateCreate).IsRequired();
            //modelBuilder.Entity<MedicineBill>().Property(c => c.PayStatus).IsRequired();
            //modelBuilder.Entity<MedicineBill>().Property(c => c.DateCreate).HasDefaultValue(DateTime.Now);

            //modelBuilder.Entity<MedicineBillInfo>().Property(c => c.IdMedicineInfo).IsRequired();
            //modelBuilder.Entity<MedicineBillInfo>().Property(c => c.MedicineBillID).IsRequired();
            //modelBuilder.Entity<MedicineBillInfo>().Property(c => c.Price).IsRequired();
            //modelBuilder.Entity<MedicineBillInfo>().Property(c => c.UnitPrice).IsRequired();
            //modelBuilder.Entity<MedicineBillInfo>().Property(c => c.Quantity).IsRequired();
        }
    }
}