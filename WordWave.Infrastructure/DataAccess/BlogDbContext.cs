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
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogPostTag> BlogPostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure BlogPost
            modelBuilder.Entity<BlogPost>()
                .HasMany(bp => bp.Comments)
                .WithOne(c => c.BlogPost)
                .HasForeignKey(c => c.BlogPostId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Comment
            modelBuilder.Entity<Comment>()
                .Property(c => c.Content)
                .IsRequired();

            // Configure Tag
            modelBuilder.Entity<Tag>()
                .Property(t => t.Name)
                .IsRequired();

            // Configure BlogPostTag (Junction Table)
            modelBuilder.Entity<BlogPostTag>()
                .HasKey(bpt => new { bpt.Id, bpt.TagId });

            modelBuilder.Entity<BlogPostTag>()
                .HasOne(bpt => bpt.BlogPost)
                .WithMany(bp => bp.BlogPostTags)
                .HasForeignKey(bpt => bpt.Id);

            modelBuilder.Entity<BlogPostTag>()
                .HasOne(bpt => bpt.Tag)
                .WithMany(t => t.BlogPostTags)
                .HasForeignKey(bpt => bpt.TagId);
        }

    }
}
