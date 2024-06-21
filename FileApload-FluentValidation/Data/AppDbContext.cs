using FileApload_FluentValidation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace FileApload_FluentValidation.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Slider> Sliders { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Slider>().HasQueryFilter(m => !m.SoftDeleted);


            // base.OnModelCreating(modelBuilder);
        }
    }
}
