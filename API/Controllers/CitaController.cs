using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;    
public class CitaController: BaseController{
    private readonly IUnitOfWork _unitOfWork;
    public CitaController(IUnitOfWork unitOfWork)=> _unitOfWork = unitOfWork;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Cita>>> Get()=>Ok(await _unitOfWork.Citas.GetAllAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Cita>>> Get(int id)=>Ok(await _unitOfWork.Citas.GetByIdAsync(id));
    

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cita>> Post(Cita Cita){
        this._unitOfWork.Citas.Add(Cita);
        await _unitOfWork.SaveAsync();
        if(Cita is null){
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = Cita.Id}, Cita);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cita>> Put(int id, [FromBody]Cita newCita){    
        Cita? Cita = await _unitOfWork.Citas.GetByIdAsync(id);
        if(newCita is null){
            return BadRequest();
        }

        if(Cita is null){
            return NotFound();
        }else{
            Cita.Fecha = newCita.Fecha;
            Cita.EstadoId = newCita.EstadoId;
            Cita.MedicoId = newCita.MedicoId;            
            Cita.UsuarioId = newCita.UsuarioId;            
        }
                        
        _unitOfWork.Citas.Update(Cita);
        await _unitOfWork.SaveAsync();
        return Ok(Cita);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Cita>> Delete(int id){ 
        Cita? Cita = await _unitOfWork.Citas.GetByIdAsync(id);
        if(Cita is null){
            return NotFound();
        }

        _unitOfWork.Citas.Remove(Cita);
        await _unitOfWork.SaveAsync();
        return NoContent();    
    }
}