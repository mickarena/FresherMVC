﻿using Microsoft.EntityFrameworkCore;
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

        //public DbSet<Product> Products { get; set; }
        //public DbSet<ProductBrand> ProductBrands { get; set; }
        //public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<WorkShift> WorkShifts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<ProductBrand>().Property(p => p.Id).ValueGeneratedNever();
            //modelBuilder.Entity<Product>().Property(p => p.Id).ValueGeneratedNever();
            //modelBuilder.Entity<ProductType>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<Doctor>().Property(p => p.IdDoctor).ValueGeneratedNever();
            modelBuilder.Entity<Shift>().Property(p => p.IdShift).ValueGeneratedNever();
            modelBuilder.Entity<WorkShift>().Property(p => p.Id).ValueGeneratedNever();
        }
    }

}
