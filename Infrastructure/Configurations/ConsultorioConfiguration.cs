using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class ConsultorioConfiguration : IEntityTypeConfiguration<Consultorio>
{
    public void Configure(EntityTypeBuilder<Consultorio> builder)
    {
        builder.ToTable("consultorio");

        builder.Property(c => c.Id)
            .HasColumnName("cons_id")
            .IsRequired();

        builder.Property(c => c.Nombre)
        .HasColumnName("cons_nombre")
        .HasMaxLength(20)
        .IsRequired();
    }
}