using System.Reflection.Emit;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class EspecialidadController:BaseController{
    
    private readonly IUnitOfWork _unitOfWork;
    public EspecialidadController(IUnitOfWork unitOfWork)=> _unitOfWork = unitOfWork;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Especialidad>>> Get(){
        var nameVar = await _unitOfWork.Especialidades.GetAllAsync();
        return Ok(nameVar);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Especialidad>>> Get(int id){
        var nameVar = await _unitOfWork.Especialidades.GetByIdAsync(id);
        return Ok(nameVar);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Especialidad>> Post(Especialidad Especialidad){
        _unitOfWork.Especialidades.Add(Especialidad);
        await _unitOfWork.SaveAsync();
        if(Especialidad is null){
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = Especialidad.Id}, Especialidad);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Especialidad>> Put(int id, [FromBody]Especialidad newEspecialidad){    
        Especialidad? Especialidad = await _unitOfWork.Especialidades.GetByIdAsync(id);
        if(newEspecialidad is null){
            return BadRequest();
        }

        if(Especialidad is null){
            return NotFound();
        }else{
            Especialidad.Nombre = newEspecialidad.Nombre;           
        }
                
        _unitOfWork.Especialidades.Update(Especialidad);
        await _unitOfWork.SaveAsync();
        return Ok(Especialidad);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Especialidad>> Delete(int id){ 
        Especialidad? Especialidad = await _unitOfWork.Especialidades.GetByIdAsync(id);
        if(Especialidad is null){
            return NotFound();
        }

        _unitOfWork.Especialidades.Remove(Especialidad);
        await _unitOfWork.SaveAsync();
        return NoContent();    
    }
}