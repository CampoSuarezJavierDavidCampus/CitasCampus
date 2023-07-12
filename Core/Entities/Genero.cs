using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Genero{
    [Key]
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Abreviatura { get; set; }

    public ICollection<Usuario>? Usuarios { get; set; }

}