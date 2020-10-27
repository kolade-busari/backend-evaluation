using IntegraAdmin.Core.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySql.Data.Entity;
using System.Data.Entity;

namespace IntegraAdmin.Persistence
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public Microsoft.EntityFrameworkCore.DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Customer> Customers { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Sponsor> Sponsors { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerProduct>().HasKey(cp =>
                new { cp.CustomerId, cp.ProductId });
            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseMySql("server=127.0.0.1;port=3305;user=root;password=;database=integra")
        //        .UseLoggerFactory(LoggerFactory.Create(b => b
        //            .AddConsole()
        //            .AddFilter(level => level >= LogLevel.Information)))
        //            .EnableSensitiveDataLogging()
        //            .EnableDetailedErrors();
        //}
    }
}
