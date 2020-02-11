using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IskconKBCServer.Models;
using Microsoft.AspNetCore.Http;

namespace IskconKBCServer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public DbSet<Devotee> Devotees { get; set; }
        public DbSet<DevoteeDetail> DevoteeDetails { get; set; }
        public DbSet<DevoteeLanguageProficiency> DevoteeLanguageProficiencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Devotee>().ToTable("Devotee");
            modelBuilder.Entity<DevoteeDetail>().ToTable("DevoteeDetail");
            modelBuilder.Entity<DevoteeLanguageProficiency>().ToTable("DevoteeLanguageProficiency");
        }
    }
}
