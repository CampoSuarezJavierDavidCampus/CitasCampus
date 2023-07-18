using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class MedicoController:BaseController{
    
    private readonly IUnitOfWork _unitOfWork;
    public MedicoController(IUnitOfWork unitOfWork)=> _unitOfWork = unitOfWork;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Medico>>> Get()=>Ok(await _unitOfWork.Medicos.GetAllAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Medico>>> Get(int id)=> Ok(await _unitOfWork.Medicos.GetByIdAsync(id));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Medico>> Post(Medico Medico){
        _unitOfWork.Medicos.Add(Medico);
        await _unitOfWork.SaveAsync();
        if(Medico is null){
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = Medico.Id}, Medico);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Medico>> Put(int id, [FromBody]Medico newMedico){    
        Medico? Medico = await _unitOfWork.Medicos.GetByIdAsync(id);
        if(newMedico is null){
            return BadRequest();
        }

        if(Medico is null){
            return NotFound();
        }else{
            Medico.Nombre = newMedico.Nombre;
            Medico.ConsultorioId = newMedico.ConsultorioId;
            Medico.EspecialidadId = newMedico.EspecialidadId;            
        }
        
        
        _unitOfWork.Medicos.Update(Medico);
        await _unitOfWork.SaveAsync();
        return Ok(Medico);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Medico>> Delete(int id){ 
        Medico? Medico = await _unitOfWork.Medicos.GetByIdAsync(id);
        if(Medico is null){
            return NotFound();
        }

        _unitOfWork.Medicos.Remove(Medico);
        await _unitOfWork.SaveAsync();
        return NoContent();    
    }
}
