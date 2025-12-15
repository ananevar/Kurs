using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JKH.Models;
using JKH.Data;

namespace JKH.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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

        // User properties (apartments)
        public DbSet<Property> Properties => Set<Property>();

        // Billing & meters
        public DbSet<Meter> Meters => Set<Meter>();
        public DbSet<MeterReading> MeterReadings => Set<MeterReading>();
        public DbSet<ServiceType> ServiceTypes => Set<ServiceType>();
        public DbSet<Tariff> Tariffs => Set<Tariff>();
        public DbSet<Bill> Bills => Set<Bill>();
        public DbSet<BillLine> BillLines => Set<BillLine>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // -------- City --------
            builder.Entity<City>()
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Entity<City>()
                .HasIndex(x => x.Name)
                .IsUnique();

            // -------- District --------
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

            // -------- Street --------
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

            // -------- Building --------
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

            // -------- Property --------
            builder.Entity<Property>()
                .Property(x => x.UserId)
                .HasMaxLength(450)
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

            // -------- Meter --------
            builder.Entity<Meter>()
                .HasOne(x => x.Property)
                .WithMany()
                .HasForeignKey(x => x.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Meter>()
                .HasOne(x => x.ServiceType)
                .WithMany(x => x.Meters)
                .HasForeignKey(x => x.ServiceTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // -------- MeterReading --------
            builder.Entity<MeterReading>()
                .HasOne(x => x.Meter)
                .WithMany(x => x.Readings)
                .HasForeignKey(x => x.MeterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<MeterReading>()
                .HasIndex(x => new { x.MeterId, x.ReadingDate })
                .IsUnique();

            // -------- Tariff --------
            builder.Entity<Tariff>()
                .HasOne(x => x.ServiceType)
                .WithMany(x => x.Tariffs)
                .HasForeignKey(x => x.ServiceTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // -------- Bill --------
            builder.Entity<Bill>()
                .HasOne(x => x.Property)
                .WithMany(x => x.Bills)
                .HasForeignKey(x => x.PropertyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Bill>()
                .HasIndex(x => new { x.PropertyId, x.Period })
                .IsUnique();

            // -------- BillLine --------
            builder.Entity<BillLine>()
                .HasOne(x => x.Bill)
                .WithMany(x => x.Lines)
                .HasForeignKey(x => x.BillId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BillLine>()
                .HasOne(x => x.Meter)
                .WithMany(x => x.BillLines)
                .HasForeignKey(x => x.MeterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
