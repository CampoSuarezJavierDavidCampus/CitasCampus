using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Cita{
    [Key]
    public int Id { get; set; }
    public DateTime Fecha { get; set; }

    public int EstadoId { get; set; }
    public Estado? Estado { get; set; }

    public int MedicoId { get; set; }
    public Medico? Medico { get; set; }

    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
}