using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PlacementDemo.Models;

namespace PlacementDemo.Data
{
    public class LinkedInContext : DbContext
    {
        public LinkedInContext(DbContextOptions<LinkedInContext> options) : base(options) { }
        public DbSet<LinkedIn> LinkedIns { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<RoleKeyword> RoleKeywords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LinkedIn>().HasKey(a => a.LinkID); // Explicitly define the primary key
            base.OnModelCreating(modelBuilder);
        }
    }
}
