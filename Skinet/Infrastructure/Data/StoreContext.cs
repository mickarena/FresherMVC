using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entity;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext()
        {
        }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<MedicineBill>? MedicineBill { get; set; }
        public DbSet<MedicineBillInfo>? MedicineBillInfo { get; set; }
        public DbSet<MedicineInfomation>? MedicineInfomation { get; set; }
        public DbSet<MedicineType>? MedicineType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-1D6NN35;Database=FresherSkiNet;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MedicineType>().HasKey(c => c.ID);
            modelBuilder.Entity<MedicineBill>().HasKey(c => c.IDBill);
            modelBuilder.Entity<MedicineInfomation>().HasKey(c => c.Id);
            modelBuilder.Entity<MedicineBillInfo>().HasKey(c => c.BillInfoID);
            modelBuilder.Entity<MedicineInfomation>().HasOne(a => a.MedicineType).WithMany(c => c.MedicineInfomations).HasForeignKey(d => d.IdType);
            modelBuilder.Entity<MedicineBillInfo>().HasOne(a => a.MedicineBills).WithMany(c => c.MedicineBillInfo).HasForeignKey(d => d.BillId);
        }
    }
}