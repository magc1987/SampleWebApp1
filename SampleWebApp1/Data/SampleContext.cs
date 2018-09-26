using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleWebApp1.Model;

namespace SampleWebApp1.Data
{
    public class SampleContext : DbContext
    {
        public SampleContext (DbContextOptions<SampleContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Admission> Admissions { get; set; }
        public DbSet<ItemOrderDetail> ItemOrderDetails { get; set; }
        public DbSet<Supply> Supplies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set default value for created data column for tables below
            modelBuilder.Entity<Patient>().Property(p => p.CreatedDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Admission>().Property(p => p.CreatedDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<ItemOrderDetail>().Property(p => p.CreatedDate).HasDefaultValueSql("getdate()");

            //set database enerated value for lastupdate column for tables below
            modelBuilder.Entity<Patient>().Property(p => p.LastModified).HasComputedColumnSql("getdate()");
            modelBuilder.Entity<Admission>().Property(p => p.LastModified).HasComputedColumnSql("getdate()");
            modelBuilder.Entity<ItemOrderDetail>().Property(p => p.LastModified).HasComputedColumnSql("getdate()");
        }
    }
}
