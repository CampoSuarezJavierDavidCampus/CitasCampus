namespace API.DTOs;
public class UsuarioDto
{
    public int Id_User { get; set; }
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber{ get; set; } = null!;    
    public string Email{ get; set; } = null!;
}