using System.Reflection.Emit;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class ConsultorioController:BaseController{
    
    private readonly IUnitOfWork _unitOfWork;
    public ConsultorioController(IUnitOfWork unitOfWork)=> _unitOfWork = unitOfWork;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Consultorio>>> Get(){
        var nameVar = await _unitOfWork.Consultorios.GetAllAsync();
        return Ok(nameVar);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Consultorio>>> Get(int id){
        var nameVar = await _unitOfWork.Consultorios.GetByIdAsync(id);
        return Ok(nameVar);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Consultorio>> Post(Consultorio Consultorio){
        _unitOfWork.Consultorios.Add(Consultorio);
        await _unitOfWork.SaveAsync();
        if(Consultorio is null){
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = Consultorio.Id}, Consultorio);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Consultorio>> Put(int id, [FromBody]Consultorio newConsultorio){    
        Consultorio? Consultorio = await _unitOfWork.Consultorios.GetByIdAsync(id);
        if(newConsultorio is null){
            return BadRequest();
        }

        if(Consultorio is null){
            return NotFound();
        }else{
            Consultorio.Nombre = newConsultorio.Nombre;          
        }
        
        
        _unitOfWork.Consultorios.Update(Consultorio);
        await _unitOfWork.SaveAsync();
        return Ok(Consultorio);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Consultorio>> Delete(int id){ 
        Consultorio? Consultorio = await _unitOfWork.Consultorios.GetByIdAsync(id);
        if(Consultorio is null){
            return NotFound();
        }

        _unitOfWork.Consultorios.Remove(Consultorio);
        await _unitOfWork.SaveAsync();
        return NoContent();    
    }
}