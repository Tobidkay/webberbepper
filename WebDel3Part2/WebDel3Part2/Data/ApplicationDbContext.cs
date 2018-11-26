﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebDel3Part2.Models;

namespace WebDel3Part2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //Setting composit keys with fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ComponentCategoryType>()
                .HasKey(c => new { c.CategoryId, c.ComponentTypeId });
        }
        //Setting composit keys with fluent API
        public DbSet<WebDel3Part2.Models.Component> Component { get; set; }
        //Setting composit keys with fluent API
        public DbSet<WebDel3Part2.Models.Category> Category { get; set; }
        //Setting composit keys with fluent API
        public DbSet<WebDel3Part2.Models.ComponentType> ComponentType { get; set; }
    }
}