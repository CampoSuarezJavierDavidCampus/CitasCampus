using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
{
    public void Configure(EntityTypeBuilder<Genero> builder)
    {
        builder.ToTable("genero");

        builder.Property(g => g.Id)
            .HasColumnName("gen_id")
            .IsRequired();

        builder.Property(g => g.Nombre)
        .HasColumnName("gen_nombre")
        .HasMaxLength(20)
        .IsRequired();

        builder.Property(g => g.Abreviatura)
        .HasColumnName("gen_abreviatura")
        .HasMaxLength(20)
        .IsRequired();

    }
}