using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordWave.Domain.Entities;

namespace WordWave.Infrastructure.DataAccess
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<BlogPostComment> BlogPostComments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPostComment>()
          .HasKey(bc => new { bc.BlogPostId, bc.CommentId });

            modelBuilder.Entity<BlogPostComment>()
                .HasOne(bc => bc.BlogPost)
                .WithMany(b => b.BlogPostComments)
                .HasForeignKey(bc => bc.BlogPostId);

            modelBuilder.Entity<BlogPostComment>()
                .HasOne(bc => bc.Comment)
                .WithMany(c => c.BlogPostComments)
                .HasForeignKey(bc => bc.CommentId);

           
        }

    }
}

