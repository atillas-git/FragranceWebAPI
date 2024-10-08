﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Context
{
    public class FragranceDbContext : DbContext
    {
        public DbSet<Fragrance> Fragrances { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<FragranceNote> FragranceNotes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FragranceCreator> FragranceCreators { get; set; }
        public DbSet<FragranceFragranceNote> FragranceFragranceNotes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
        public FragranceDbContext(DbContextOptions<FragranceDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Many-to-Many: Article <-> Fragrance
            modelBuilder.Entity<Article>()
                .HasMany(a => a.RelatedFragrances)
                .WithMany(f => f.RelatedArticles)
                .UsingEntity<Dictionary<string, object>>(
                    "ArticleFragrance",  // Name of the join table
                    af => af.HasOne<Fragrance>().WithMany().HasForeignKey("FragranceId"),
                    af => af.HasOne<Article>().WithMany().HasForeignKey("ArticleId")
                );

            // Many-to-Many: Article <-> Brand
            modelBuilder.Entity<Article>()
                .HasMany(a => a.RelatedBrands)
                .WithMany(b => b.RelatedArticles)
                .UsingEntity<Dictionary<string, object>>(
                    "ArticleBrand",  // Name of the join table
                    ab => ab.HasOne<Brand>().WithMany().HasForeignKey("BrandId"),
                    ab => ab.HasOne<Article>().WithMany().HasForeignKey("ArticleId")
                );

            // Many-to-Many: Article <-> Creator
            modelBuilder.Entity<Article>()
                .HasMany(a => a.RelatedCreators)
                .WithMany(c => c.RelatedArticles)
                .UsingEntity<Dictionary<string, object>>(
                    "ArticleCreator",  // Name of the join table
                    ac => ac.HasOne<Creator>().WithMany().HasForeignKey("CreatorId"),
                    ac => ac.HasOne<Article>().WithMany().HasForeignKey("ArticleId")
                );

            // Configure FragranceCreator many-to-many relationship
            modelBuilder.Entity<FragranceCreator>()
                .HasKey(fc => new { fc.FragranceId, fc.CreatorId });

            modelBuilder.Entity<FragranceCreator>()
                .HasOne(fc => fc.Fragrance)
                .WithMany(f => f.FragranceCreators)
                .HasForeignKey(fc => fc.FragranceId);

            modelBuilder.Entity<FragranceCreator>()
                .HasOne(fc => fc.Creator)
                .WithMany(c => c.FragranceCreators)
                .HasForeignKey(fc => fc.CreatorId);

            // Configure FragranceFragranceNote many-to-many relationship
            modelBuilder.Entity<FragranceFragranceNote>()
                .HasKey(ffn => new { ffn.FragranceId, ffn.FragranceNoteId });

            modelBuilder.Entity<FragranceFragranceNote>()
                .HasOne(ffn => ffn.Fragrance)
                .WithMany(f => f.FragranceFragranceNotes)
                .HasForeignKey(ffn => ffn.FragranceId);

            modelBuilder.Entity<FragranceFragranceNote>()
                .HasOne(ffn => ffn.FragranceNote)
                .WithMany(fn => fn.FragranceFragranceNotes)
                .HasForeignKey(ffn => ffn.FragranceNoteId);

            // Configure Rating relationships
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Fragrance)
                .WithMany(f => f.Ratings)
                .HasForeignKey(r => r.FragranceId);

            // Configure Comment relationships
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Fragrance)
                .WithMany(f => f.Comments)
                .HasForeignKey(c => c.FragranceId);

            base.OnModelCreating(modelBuilder);
        }
    }

}
