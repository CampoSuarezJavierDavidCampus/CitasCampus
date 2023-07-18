namespace API.DTOs;
public class GeneroDto
{
    public int Id_Gender { get; set; }
    public string? Gender { get; set; }
    public string? Prefix { get; set; }
    
    public List<UsuarioDto> Users { get; set; } = null!;

}