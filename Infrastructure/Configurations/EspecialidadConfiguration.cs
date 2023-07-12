using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class EspecialidadConfiguration : IEntityTypeConfiguration<Especialidad>
{
    public void Configure(EntityTypeBuilder<Especialidad> builder){
        builder.ToTable("especialidad");

        builder.Property(e => e.Id)
            .HasColumnName("esp_id")
            .IsRequired();

        builder.Property(e => e.Nombre)
        .HasColumnName("esp_nombre")
        .HasMaxLength(20)
        .IsRequired();
    }
}