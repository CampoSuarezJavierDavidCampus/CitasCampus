using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class GeneroController:BaseController{
    
    private readonly IUnitOfWork _unitOfWork;
    public GeneroController(IUnitOfWork unitOfWork)=> _unitOfWork = unitOfWork;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Genero>>> Get(){
        var nameVar = await _unitOfWork.Generos.GetAllAsync();
        return Ok(nameVar);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Genero>>> Get(int id){
        var nameVar = await _unitOfWork.Generos.GetByIdAsync(id);
        return Ok(nameVar);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Genero>> Post(Genero Genero){
        _unitOfWork.Generos.Add(Genero);
        await _unitOfWork.SaveAsync();
        if(Genero is null){
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = Genero.Id}, Genero);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Genero>> Put(int id, [FromBody]Genero newGenero){    
        Genero? Genero = await _unitOfWork.Generos.GetByIdAsync(id);
        if(newGenero is null){
            return BadRequest();
        }

        if(Genero is null){
            return NotFound();
        }else{
            Genero.Nombre = newGenero.Nombre;
            Genero.Abreviatura = newGenero.Abreviatura;                    
        }
        
        
        _unitOfWork.Generos.Update(Genero);
        await _unitOfWork.SaveAsync();
        return Ok(Genero);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Genero>> Delete(int id){ 
        Genero? Genero = await _unitOfWork.Generos.GetByIdAsync(id);
        if(Genero is null){
            return NotFound();
        }

        _unitOfWork.Generos.Remove(Genero);
        await _unitOfWork.SaveAsync();
        return NoContent();    
    }
}