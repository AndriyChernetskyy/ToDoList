﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ToDoList.Models
{
    public class PlannerContext : DbContext
    {
        public PlannerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DailyPlan> Planners { get; set; } 
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DailyPlan>()
                .HasOne(x => x.User)
                .WithMany(x => x.Plans)
                .HasForeignKey(x => x.UserId);
        }
    }
}
