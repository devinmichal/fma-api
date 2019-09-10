using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FMA.API.Entities
{
    public class FmaContext : DbContext
    {
        public FmaContext(DbContextOptions<FmaContext> options) : 
            base(options)
        {
            Database.Migrate();
        }
        public DbSet<Character> Characters { get; set; }
       
        public DbSet<Capital> Capitals { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Character>()
                .HasOne(c => c.Occupation)
                .WithMany(o => o.Members);
            modelBuilder.Entity<Character>()
               .HasOne(c => c.Nationality)
               .WithMany(n => n.Members);
            modelBuilder.Entity<Country>()
              .HasMany(cty => cty.Members)
              .WithOne(c => c.Country)
              .HasForeignKey(c => c.CountryId)
              .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Capital>()
                .HasOne(cp => cp.Country)
                .WithOne(cty => cty.Capital)
                .HasForeignKey<Country>(cty => cty.CapitalId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Nationality>()
                .HasOne(n => n.Country)
                .WithOne(cty => cty.Nationality)
                .HasForeignKey<Country>(cty => cty.NationalityId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Occupation>()
                .HasMany(o => o.Members)
                .WithOne(c => c.Occupation)
                .HasForeignKey(c => c.OccupationId)
                .OnDelete(DeleteBehavior.SetNull);




        }
    }
}
