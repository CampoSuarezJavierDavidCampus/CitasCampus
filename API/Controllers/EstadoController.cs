using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class EstadoController:BaseController{
    
    private readonly IUnitOfWork _unitOfWork;
    public EstadoController(IUnitOfWork unitOfWork)=> _unitOfWork = unitOfWork;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Estado>>> Get(){
        var nameVar = await _unitOfWork.Estados.GetAllAsync();
        return Ok(nameVar);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Estado>>> Get(int id){
        var nameVar = await _unitOfWork.Estados.GetByIdAsync(id);
        return Ok(nameVar);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Estado>> Post(Estado Estado){
        _unitOfWork.Estados.Add(Estado);
        await _unitOfWork.SaveAsync();
        if(Estado is null){
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = Estado.Id}, Estado);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Estado>> Put(int id, [FromBody]Estado newEstado){    
        Estado? Estado = await _unitOfWork.Estados.GetByIdAsync(id);
        if(newEstado is null){
            return BadRequest();
        }

        if(Estado is null){
            return NotFound();
        }else{
            Estado.Nombre = newEstado.Nombre;          
        }
        
        
        _unitOfWork.Estados.Update(Estado);
        await _unitOfWork.SaveAsync();
        return Ok(Estado);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Estado>> Delete(int id){ 
        Estado? Estado = await _unitOfWork.Estados.GetByIdAsync(id);
        if(Estado is null){
            return NotFound();
        }

        _unitOfWork.Estados.Remove(Estado);
        await _unitOfWork.SaveAsync();
        return NoContent();    
    }
}