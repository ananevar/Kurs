using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JKH.Models;

namespace JKH.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Address hierarchy
        public DbSet<City> Cities => Set<City>();
        public DbSet<District> Districts => Set<District>();
        public DbSet<Street> Streets => Set<Street>();
        public DbSet<Building> Buildings => Set<Building>();

        // Main user object
        public DbSet<Property> Properties => Set<Property>();

        // Если у тебя есть счета/строки/счетчики — раскомментируй и добавь модели
        // public DbSet<Bill> Bills => Set<Bill>();
        // public DbSet<BillLine> BillLines => Set<BillLine>();
        // public DbSet<Meter> Meters => Set<Meter>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // City: unique name
            builder.Entity<City>()
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Entity<City>()
                .HasIndex(x => x.Name)
                .IsUnique();

            // District: unique within City
            builder.Entity<District>()
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Entity<District>()
                .HasOne(x => x.City)
                .WithMany(x => x.Districts)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<District>()
                .HasIndex(x => new { x.CityId, x.Name })
                .IsUnique();

            // Street: unique within District
            builder.Entity<Street>()
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Entity<Street>()
                .HasOne(x => x.District)
                .WithMany(x => x.Streets)
                .HasForeignKey(x => x.DistrictId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Street>()
                .HasIndex(x => new { x.DistrictId, x.Name })
                .IsUnique();

            // Building: unique (StreetId + Number)
            builder.Entity<Building>()
                .Property(x => x.Number)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<Building>()
                .HasOne(x => x.Street)
                .WithMany(x => x.Buildings)
                .HasForeignKey(x => x.StreetId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Building>()
                .HasIndex(x => new { x.StreetId, x.Number })
                .IsUnique();

            // Property: user + building + apartment
            builder.Entity<Property>()
                .Property(x => x.UserId)
                .HasMaxLength(450) // стандартная длина ключа Identity user id
                .IsRequired();

            builder.Entity<Property>()
                .Property(x => x.Apartment)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<Property>()
                .HasOne(x => x.Building)
                .WithMany(x => x.Properties)
                .HasForeignKey(x => x.BuildingId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Property>()
                .HasIndex(x => new { x.UserId, x.BuildingId, x.Apartment })
                .IsUnique();

            // Если у тебя Bill/BillLine и была рекурсия — позже настроим JSON / навигации отдельно
        }
    }
}
