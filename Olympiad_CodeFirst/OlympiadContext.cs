using Microsoft.EntityFrameworkCore;
using Olympiad_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olympiad_CodeFirst
{
    class OlympiadContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Sportsman> Sportsmen { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<SportsSportsmen> SportsSportsmen { get; set; }
        public DbSet<Medal> Medals{ get; set; }
        public DbSet<Award> Awards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13; Initial Catalog=Opympiad; Integrated Security=true;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany<Sportsman>(c => c.Sportsmen)
                .WithOne(s => s.Country)
                .HasForeignKey(s => s.CountryId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Sportsman>()
                .HasOne<Country>(s => s.Country)
                .WithMany(c => c.Sportsmen)
                .HasForeignKey(s => s.CountryId);

            modelBuilder.Entity<Sportsman>()
                .HasMany<SportsSportsmen>(ss => ss.SportsSportsmen)
                .WithOne(s => s.Sportsman)
                .HasForeignKey(ss => ss.SportsmanId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Sportsman>()
                .HasMany<Award>(s => s.Awards)
                .WithOne(a => a.Sportsman)
                .HasForeignKey(a => a.SportsmanId)
                .OnDelete(DeleteBehavior.Cascade);
                

            modelBuilder.Entity<Sport>()
                .HasMany<SportsSportsmen>(ss => ss.SportsSportsmen)
                .WithOne(s => s.Sport)
                .HasForeignKey(ss => ss.SportId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Sport>()
                .HasMany<Award>(s => s.Awards)
                .WithOne(a => a.Sport)
                .HasForeignKey(a => a.SportId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<SportsSportsmen>().HasKey(ss => new { ss.SportId, ss.SportsmanId });

            modelBuilder.Entity<SportsSportsmen>()
                .HasOne<Sport>(ss => ss.Sport)
                .WithMany(s => s.SportsSportsmen)
                .HasForeignKey(ss => ss.SportId);

            modelBuilder.Entity<SportsSportsmen>()
                .HasOne<Sportsman>(ss => ss.Sportsman)
                .WithMany(s => s.SportsSportsmen)
                .HasForeignKey(ss => ss.SportsmanId);

            
            modelBuilder.Entity<Medal>()
                .HasMany<Award>(m => m.Awards)
                .WithOne(a => a.Medal)
                .HasForeignKey(a => a.MedalId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Award>()
                .HasOne<Sport>(a => a.Sport)
                .WithMany(s => s.Awards)
                .HasForeignKey(a => a.SportId);

            modelBuilder.Entity<Award>()
                .HasOne<Sportsman>(a => a.Sportsman)
                .WithMany(s => s.Awards)
                .HasForeignKey(a => a.SportsmanId);

            modelBuilder.Entity<Award>()
                .HasOne<Medal>(a => a.Medal)
                .WithMany(m => m.Awards)
                .HasForeignKey(a => a.MedalId);
        }
    }
}
