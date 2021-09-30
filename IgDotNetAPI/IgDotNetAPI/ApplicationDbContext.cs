using IgDotNetAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgDotNetAPI
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Follower>()
                .HasKey(f => new { f.UserId, f.UserFollowerId });
            modelBuilder.Entity<Like>()
                .HasKey(l => new { l.PostId, l.UserId });
        }

        virtual public DbSet<Post> Posts { get; set; }
        virtual public DbSet<Follower> Followers { get; set; }
    }
}
