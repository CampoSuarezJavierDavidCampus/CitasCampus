using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("estado_cita");

        builder.Property(e => e.Id)
            .HasColumnName("estcita_id")
            .IsRequired();

        builder.Property(e => e.Nombre)
        .HasColumnName("estcita_nombre")
        .HasMaxLength(20)
        .IsRequired();
    }
}