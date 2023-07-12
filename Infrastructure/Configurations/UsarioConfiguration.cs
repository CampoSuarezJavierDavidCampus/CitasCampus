using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class UsarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuario");
        
        builder.Property(u => u.Id)
            .HasColumnName("usu_id")
            .IsRequired();

        builder.Property(u => u.PrimerNombre)
            .HasColumnName("usu_nombre")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.SegundoNombre)
            .HasColumnName("usu_segdo_nombre")
            .HasMaxLength(45);

        builder.Property(u => u.PrimerApellido)
            .HasColumnName("usu_primer_apellido")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.SegundoApellido)
            .HasColumnName("usu_segdo_apellido")
            .HasMaxLength(50);
        
        builder.Property(u => u.Telefono)
            .HasColumnName("usu_telefono")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.Direccion)
            .HasColumnName("usu_direccion")
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(u => u.Email)
            .HasColumnName("usu_e-mail")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.TipoDocumentoId)
            .HasColumnName("usu_tipdoc")
            .IsRequired();

        builder.Property(u => u.GeneroId)
            .HasColumnName("usu_genero")
            .IsRequired();

        builder.Property(u => u.AcudienteId)
            .HasColumnName("usu_acudiente")
            .IsRequired();

        builder.HasOne(u => u.TipoDocumento)
            .WithMany(tp => tp.Usuarios)
            .HasForeignKey(u => u.TipoDocumentoId);

        builder.HasOne(u => u.Genero)
            .WithMany(tp => tp.Usuarios)
            .HasForeignKey(u => u.GeneroId);

        builder.HasOne(u => u.Acudiente)
            .WithMany(tp => tp.Usuarios)
            .HasForeignKey(u => u.AcudienteId);
    }
}