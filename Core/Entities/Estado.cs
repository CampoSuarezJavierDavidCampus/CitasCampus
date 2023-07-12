using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Estado{
    [Key]
    public int Id { get; set; }    
    public string? Nombre { get; set; }    

    public ICollection<Cita>? Citas { get; set; }

}