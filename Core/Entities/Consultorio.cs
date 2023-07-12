using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Consultorio{
    [Key]
    public int Id { get; set; }    
    public string? Nombre { get; set; }  

    public ICollection<Medico>? Medicos { get; set; }
}