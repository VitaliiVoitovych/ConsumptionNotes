using ConsumptionNotes.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsumptionNotes.Dal;

public sealed class ConsumptionNotesDbContext : DbContext
{
    public DbSet<ElectricityConsumption> ElectricityConsumptions => Set<ElectricityConsumption>();
    public DbSet<NaturalGasConsumption> NaturalGasConsumptions => Set<NaturalGasConsumption>();

    public ConsumptionNotesDbContext(DbContextOptions<ConsumptionNotesDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ElectricityConsumption>()
            .Property(e => e.AmountToPay)
            .HasConversion<double>();

        modelBuilder.Entity<NaturalGasConsumption>()
            .Property(n => n.AmountToPay)
            .HasConversion<double>();
    }
}