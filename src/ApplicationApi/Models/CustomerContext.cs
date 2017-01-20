using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationApi.Models
{
    public class CustomerContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        //public CustomerContext ()
        //{
        //    this.
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string db = "ApplicantDB";
            string server = "localhost";
            optionsBuilder.UseSqlServer($"Server={server};Database={db};Trusted_Connection=True;");
        }

        // composite key
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(c => new { c.email, c.experienceTitle });
        }
    }
}
