using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Medico{
    [Key]
    public int Id { get; set; }    
    public string? Nombre { get; set; }    

    public int? ConsultorioId { get; set; }    
    public Consultorio? Consultorio { get; set; }
    
    public int? EspecialidadId { get; set; }    
    public Especialidad? Especialidad { get; set; }

    public ICollection<Cita>? Citas { get; set; }
}