using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class AcudienteConfiguration: IEntityTypeConfiguration<Acudiente>{    
    public void Configure(EntityTypeBuilder<Acudiente> builder){
        builder.ToTable("acudiente");

        builder.Property(a => a.Id)
            .HasColumnName("acu_codigo")
            .IsRequired();

        builder.Property(a => a.Nombre)
            .HasColumnName("acu_nombreCompleto")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.Telefono)
            .HasColumnName("acu_telefono")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.Direccion)
            .HasColumnName("acu_direccion")
            .HasMaxLength(200)
            .IsRequired();
    }
}