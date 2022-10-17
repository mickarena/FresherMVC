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

        public DbSet<Product> Products { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<MedicineBillInfo>? MedicineBillInfos { get; set; }
        public DbSet<MedicineInfomation>? MedicineInfomations { get; set; }
        public DbSet<MedicineType>? MedicineTypes { get; set; }
        public DbSet<MedicineBill>? MedicineBills { get; set; }
        public DbSet<HospitalBed> HospitalBeds { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<WorkShift> WorkShifts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-1D6NN35;Database=Skinetv6;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

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

            modelBuilder.Entity<Doctor>().Property(d => d.Birthday).HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<MedicineInfomation>().Property(c => c.ImportDate).HasDefaultValue(DateTime.UtcNow);
            modelBuilder.Entity<MedicineInfomation>().Property(c => c.Quantity).HasDefaultValue(1);
            modelBuilder.Entity<MedicineBill>().Property(c => c.DateCreate).HasDefaultValue(DateTime.Now);

            //fresher-2410-start
            modelBuilder.Entity<Shift>().HasKey(c => c.Id);
            modelBuilder.Entity<Doctor>().HasKey(c => c.Id);
            modelBuilder.Entity<WorkShift>().HasKey(c => c.Id);
            modelBuilder.Entity<WorkShift>().HasOne(a => a.Shift).WithMany(c => c.WorkShift).HasForeignKey(d => d.IdShift);
            modelBuilder.Entity<WorkShift>().HasOne(a => a.Doctor).WithMany(c => c.WorkShift).HasForeignKey(d => d.IdDoctor);
            modelBuilder.Entity<WorkShift>().Property(c => c.CreateAt).HasDefaultValue(DateTime.Now);
            //
        }
    }
}