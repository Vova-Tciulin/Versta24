using Microsoft.EntityFrameworkCore;
using Versta24.Domain.Entities;

namespace Versta24.Infrastructure.Data;

public class VerstaDbContext:DbContext
{
    public DbSet<Order> Orders { get; set; }

    public VerstaDbContext(DbContextOptions<VerstaDbContext> options)
        :base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VerstaDbContext).Assembly);
    }
}