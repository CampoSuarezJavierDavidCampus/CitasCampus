using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class TipoDocumentoConfiguration: IEntityTypeConfiguration<TipoDocumento>{
    public void Configure(EntityTypeBuilder<TipoDocumento> builder){
        builder.ToTable("tipo_documento");
        
        builder.Property(tp => tp.Id)
            .HasColumnName("tipdoc_id")
            .IsRequired();

        builder.Property(tp => tp.Nombre)
        .HasColumnName("tipdoc_nombre")
        .HasMaxLength(20)
        .IsRequired();

        builder.Property(tp => tp.Abreviatura)
        .HasColumnName("tipdoc_abreviatura")
        .HasMaxLength(20)
        .IsRequired();
    }    
    
}