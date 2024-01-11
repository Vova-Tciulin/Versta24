using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Versta24.Domain.Entities;

namespace Versta24.Infrastructure.Data.Configurations;

public class OrderConfiguration:IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.SenderCity).IsRequired();
        builder.Property(u => u.SenderAddress).IsRequired();
        builder.Property(u => u.RecipientCity).IsRequired();
        builder.Property(u => u.RecipientAddress).IsRequired();
        builder.Property(u => u.DateReceived)
            .HasColumnType("date")
            .IsRequired();
        builder.Property(u=>u.CargoWeight)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
    }
}