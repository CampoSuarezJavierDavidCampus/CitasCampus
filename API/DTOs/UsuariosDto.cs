namespace API.DTOs;
public class UsuariosDto
{
    public int Id_User { get; set; }
    public string Name { get; set; } = null!;
    public string? SecondName { get; set; }
    public string LastName { get; set; } = null!;
    public string? SecondLastName { get; set; }
    public string PhoneNumber{ get; set; } = null!;
    public string Address{ get; set; } = null!;
    public string Email{ get; set; } = null!;
    
    public AcudienteDto Contact { get; set; } = null!;
    public GeneroDto Gender { get; set; } = null!;
    public TipoDocumentoDto DocumentType { get; set; } = null!;

}