using System.ComponentModel.DataAnnotations;

namespace Core.Entities;    
public class Usuario{        
    [Key]
    public int Id { get; set; }
    public string? PrimerNombre { get; set; }
    public string? SegundoNombre { get; set; }
    public string? PrimerApellido { get; set; }
    public string? SegundoApellido { get; set; }
    public string? Telefono{ get; set; }
    public string? Direccion{ get; set; }
    public string? Email{ get; set; }

    public int? TipoDocumentoId{ get; set; }
    public TipoDocumento? TipoDocumento{ get; set; }

    public int? GeneroId{ get; set; }
    public Genero? Genero{ get; set; }

    public int? AcudienteId{ get; set; }
    public Acudiente? Acudiente{ get; set; }

    public ICollection<Cita>? Citas { get; set; }
}