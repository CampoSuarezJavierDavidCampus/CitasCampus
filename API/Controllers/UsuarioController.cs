using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class UsuarioController:BaseController{
    
    private readonly IUnitOfWork _unitOfWork;
    public UsuarioController(IUnitOfWork unitOfWork)=> _unitOfWork = unitOfWork;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Usuario>>> Get()=>Ok(await _unitOfWork.Usuarios.GetAllAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Usuario>>> Get(int id)=> Ok(await _unitOfWork.Usuarios.GetByIdAsync(id));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Usuario>> Post(Usuario Usuario){
        this._unitOfWork.Usuarios.Add(Usuario);
        await _unitOfWork.SaveAsync();
        if(Usuario is null){
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = Usuario.Id}, Usuario);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Usuario>> Put(int id, [FromBody]Usuario newUsuario){    
        Usuario? Usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
        if(newUsuario is null){
            return BadRequest();
        }

        if(Usuario is null){
            return NotFound();
        }else{
            Usuario.PrimerNombre = newUsuario.PrimerNombre;
            Usuario.SegundoNombre = newUsuario.SegundoNombre;
            Usuario.PrimerApellido = newUsuario.PrimerApellido;
            Usuario.SegundoApellido = newUsuario.SegundoApellido;
            Usuario.Telefono = newUsuario.Telefono;            
            Usuario.Direccion = newUsuario.Direccion;            
            Usuario.Email = newUsuario.Email;            
            Usuario.TipoDocumentoId = newUsuario.TipoDocumentoId;            
            Usuario.GeneroId = newUsuario.GeneroId;            
            Usuario.AcudienteId = newUsuario.AcudienteId;            
        }
        
        
        _unitOfWork.Usuarios.Update(Usuario);
        await _unitOfWork.SaveAsync();
        return Ok(Usuario);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Usuario>> Delete(int id){ 
        Usuario? Usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
        if(Usuario is null){
            return NotFound();
        }

        _unitOfWork.Usuarios.Remove(Usuario);
        await _unitOfWork.SaveAsync();
        return NoContent();    
    }
}