using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Nurse> Nurse { get; set; }

        public DbSet<Departments> Departments { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<MedicineBillInfo>? MedicineBillInfos { get; set; }
        public DbSet<MedicineInfomation>? MedicineInfomations { get; set; }
        public DbSet<MedicineType>? MedicineTypes { get; set; }
        public DbSet<MedicineBill>? MedicineBills { get; set; }
        public DbSet<HospitalBed> HospitalBeds { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<WorkShift> WorkShifts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<ProductBrand>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<ProductType>().Property(p => p.Id).ValueGeneratedNever();

            modelBuilder.Entity<MedicineInfomation>().HasOne(a => a.MedicineTypes).WithMany(c => c.MedicineInfomations).HasForeignKey(d => d.MedicineIDType);
            modelBuilder.Entity<MedicineBillInfo>().HasOne(a => a.MedicineBills).WithMany(c => c.MedicineBillInfos).HasForeignKey(d => d.MedicineBillID);
            modelBuilder.Entity<MedicineBillInfo>().HasOne(a => a.MedicineInfomations).WithMany(c => c.MedicineBillInfos).HasForeignKey(d => d.IdMedicineInfo);

            //Thuộc tính của model edit từ đây
            modelBuilder.Entity<MedicineInfomation>().Property(c => c.ImportDate).HasDefaultValue(DateTime.UtcNow);
            modelBuilder.Entity<MedicineBill>().Property(c => c.DateCreate).HasDefaultValue(DateTime.UtcNow);
            //fresher-2410-start
            modelBuilder.Entity<Shift>().HasKey(c => c.IdShift);
            modelBuilder.Entity<WorkShift>().HasKey(c => c.IdWork);
            modelBuilder.Entity<WorkShift>().HasOne(a => a.Shift).WithMany(c => c.WorkShift).HasForeignKey(d => d.IdShift);
            //
        }
    }
}