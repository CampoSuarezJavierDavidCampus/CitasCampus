using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
{
    public void Configure(EntityTypeBuilder<Medico> builder)
    {
        builder.ToTable("medicos");
        builder.Property(m => m.Id)
            .HasColumnName("med_nroMatriculaProfecional")
            .IsRequired();

        builder.Property(m => m.Nombre)
            .HasColumnName("med_nombreCompleto")
            .HasMaxLength(120)
            .IsRequired();

        builder.Property(m => m.ConsultorioId)
            .HasColumnName("med_consultorio")
            .IsRequired();
        
        builder.Property(m => m.EspecialidadId)
            .HasColumnName("med_especialidad")
            .IsRequired();
        
        builder.HasOne(m => m.Consultorio)
            .WithMany(c => c.Medicos)
            .HasForeignKey(m => m.ConsultorioId);

        builder.HasOne(m => m.Especialidad)
            .WithMany(e => e.Medicos)
            .HasForeignKey(m => m.EspecialidadId);
    }
}