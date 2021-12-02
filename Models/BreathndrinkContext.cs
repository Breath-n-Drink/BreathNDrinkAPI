﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BreathNDrinkAPI.Models
{
    public partial class BreathndrinkContext : DbContext
    {
        public BreathndrinkContext()
        {
        }

        public BreathndrinkContext(DbContextOptions<BreathndrinkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Drinkers> Drinkers { get; set; }
        public virtual DbSet<Promille> Promille { get; set; }
        public virtual DbSet<Ratings> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=eksamenprojekt3sem.database.windows.net;Initial Catalog=BreathNDrink;User ID=gruppe2;Password=!SuperPassword;Connect Timeout=30;Encrypt=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Drinkers>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Promille>(entity =>
            {
                entity.Property(e => e.DrinkerId).HasColumnName("DrinkerID");

                entity.Property(e => e.Promille1).HasColumnName("Promille");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Drinker)
                    .WithMany(p => p.Promille)
                    .HasForeignKey(d => d.DrinkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Promille__Drinke__02FC7413");
            });

            modelBuilder.Entity<Ratings>(entity =>
            {
                entity.HasKey(e => e.RatingId)
                    .HasName("PK__Table__FCCDF87C7F444D95");

                entity.HasOne(d => d.Drinker)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.DrinkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ratings__Drinker__2739D489");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}