using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;
public class AcudienteController:BaseController{

    private readonly IUnitOfWork _unitOfWork;
    public AcudienteController(IUnitOfWork unitOfWork)=> _unitOfWork = unitOfWork;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Acudiente>>> Get()=>Ok(await _unitOfWork.Acudientes.GetAllAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Acudiente>>> Get(int id)=>Ok(await _unitOfWork.Acudientes.GetByIdAsync(id));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Acudiente>> Post(Acudiente acudiente){
        this._unitOfWork.Acudientes.Add(acudiente);
        await _unitOfWork.SaveAsync();
        if(acudiente is null){
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = acudiente.Id}, acudiente);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Acudiente>> Put(int id, [FromBody]Acudiente newAcudiente){    
        Acudiente? acudiente = await _unitOfWork.Acudientes.GetByIdAsync(id);
        if(newAcudiente is null){
            return BadRequest();
        }

        if(acudiente is null){
            return NotFound();
        }else{
            acudiente.Nombre = newAcudiente.Nombre;
            acudiente.Telefono = newAcudiente.Telefono;
            acudiente.Direccion = newAcudiente.Direccion;            
        }
        
        
        _unitOfWork.Acudientes.Update(acudiente);
        await _unitOfWork.SaveAsync();
        return Ok(acudiente);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Acudiente>> Delete(int id){ 
        Acudiente? acudiente = await _unitOfWork.Acudientes.GetByIdAsync(id);
        if(acudiente is null){
            return NotFound();
        }

        _unitOfWork.Acudientes.Remove(acudiente);
        await _unitOfWork.SaveAsync();
        return NoContent();    
    }
    
}