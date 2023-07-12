using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
public class Acudiente{
    [Key]
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Telefono{ get; set; }
    public string? Direccion{ get; set; }

    public ICollection<Usuario>? Usuarios { get; set; }

}