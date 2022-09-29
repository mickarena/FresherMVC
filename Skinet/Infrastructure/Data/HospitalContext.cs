using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection;

namespace Infrastructure.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {  }

        public DbSet<Nurse> Nurse { get; set; }

        public DbSet<Departments> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProductBrand>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<Nurse>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<Departments>().Property(p => p.Id).ValueGeneratedNever();
        }
    }
}
