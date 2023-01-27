using Microsoft.EntityFrameworkCore;
using Pharmacy_Maneger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Maneger.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<SellItem> sellItems { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<BillGood> BillGoods { get; set; }

        public DbSet<Expenses> Expenses { get; set; }
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("A FALLBACK CONNECTION STRING");
                
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Customer>()
                .HasOne(c => c.Company)
                .WithMany(c => c.Customers)
                .HasForeignKey(c => c.CompanyId);*/

            modelBuilder.Entity<Company>();

            modelBuilder.Entity<Expenses>();
            

            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bills)
                .HasForeignKey(b => b.CustomerId);

            modelBuilder.Entity<BillGood>()
                .HasOne(bg => bg.Bill)
                .WithMany(b => b.BillGoods)
                .HasForeignKey(bg => bg.BillId);

            modelBuilder.Entity<BillGood>()
                .HasOne(bg => bg.Good)
                .WithMany(g => g.BillGoods)
                .HasForeignKey(bg => bg.GoodId);

           /* modelBuilder.Entity<SellItem>()
                .HasOne(c => c.company)
                .WithMany(c => c.sellItems)
                .HasForeignKey(c => c.company.Id);*/

        }


    }
}
