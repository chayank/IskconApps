using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IskconKBCServer.Models;

namespace IskconKBCServer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DevoteeDetails> DevoteeDetails { get; set; }
        public DbSet<DevoteeLanguageProficiencies> DevoteeLanguageProficiencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DevoteeDetails>().ToTable("DevoteeDetails");
            modelBuilder.Entity<DevoteeLanguageProficiencies>().ToTable("DevoteeLanguageProficiencies");
        }
    }
}
