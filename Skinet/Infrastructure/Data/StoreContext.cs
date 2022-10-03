using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public DbSet<Nurse> Nurse { get; set; }

        public DbSet<Departments> Departments { get; set; }



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
        }
    }

}
