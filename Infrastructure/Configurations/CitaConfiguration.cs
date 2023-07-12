using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class CitaConfiguration : IEntityTypeConfiguration<Cita>
{
    public void Configure(EntityTypeBuilder<Cita> builder)
    {
        builder.ToTable("cita");

        builder.Property(c => c.Id)
            .HasColumnName("cit_codigo")
            .IsRequired();

        builder.Property(c => c.Fecha)
            .HasColumnName("cit_fecha")
            .HasColumnType("date")
            .IsRequired();

        builder.Property(c => c.EstadoId)
            .HasColumnName("cit_estadoCita")
            .IsRequired();

        builder.Property(c => c.MedicoId)
            .HasColumnName("cit_medico")
            .IsRequired();

        builder.Property(c => c.UsuarioId)
            .HasColumnName("cit_datosUsuario")
            .IsRequired();

        builder.HasOne(c => c.Estado)
           .WithMany(e => e.Citas)
           .HasForeignKey(c => c.EstadoId);

        builder.HasOne(c => c.Medico)
           .WithMany(e => e.Citas)
           .HasForeignKey(c => c.MedicoId);

        builder.HasOne(c => c.Usuario)
           .WithMany(e => e.Citas)
           .HasForeignKey(c => c.UsuarioId);
    }
}