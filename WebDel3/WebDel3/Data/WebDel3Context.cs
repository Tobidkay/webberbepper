using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebDel3.Models;

namespace WebDel3.Models
{
    public class WebDel3Context : DbContext
    {
        public WebDel3Context (DbContextOptions<WebDel3Context> options)
            : base(options)
        {
        }

        public DbSet<WebDel3.Models.Component> Component { get; set; }

        //Setting composit keys with fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ComponentCategoryType>()
                .HasKey(c => new { c.CategoryId, c.ComponentTypeId });
        }

        //Setting composit keys with fluent API
        public DbSet<WebDel3.Models.Category> Category { get; set; }

        //Setting composit keys with fluent API
        public DbSet<WebDel3.Models.ComponentType> ComponentType { get; set; }
    }
}
