using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class TipoDocumentoController:BaseController{
    
    private readonly IUnitOfWork _unitOfWork;
    public TipoDocumentoController(IUnitOfWork unitOfWork)=> _unitOfWork = unitOfWork;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoDocumento>>> Get()=>Ok(await _unitOfWork.TipoDocumentos.GetAllAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoDocumento>>> Get(int id)=> Ok(await _unitOfWork.TipoDocumentos.GetByIdAsync(id));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoDocumento>> Post(TipoDocumento TipoDocumento){
        _unitOfWork.TipoDocumentos.Add(TipoDocumento);
        await _unitOfWork.SaveAsync();
        if(TipoDocumento is null){
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id = TipoDocumento.Id}, TipoDocumento);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoDocumento>> Put(int id, [FromBody]TipoDocumento newTipoDocumento){    
        TipoDocumento? TipoDocumento = await _unitOfWork.TipoDocumentos.GetByIdAsync(id);
        if(newTipoDocumento is null){
            return BadRequest();
        }

        if(TipoDocumento is null){
            return NotFound();
        }else{
            TipoDocumento.Nombre = newTipoDocumento.Nombre;
            TipoDocumento.Abreviatura = newTipoDocumento.Abreviatura;                 
        }
        
        
        _unitOfWork.TipoDocumentos.Update(TipoDocumento);
        await _unitOfWork.SaveAsync();
        return Ok(TipoDocumento);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoDocumento>> Delete(int id){ 
        TipoDocumento? TipoDocumento = await _unitOfWork.TipoDocumentos.GetByIdAsync(id);
        if(TipoDocumento is null){
            return NotFound();
        }

        _unitOfWork.TipoDocumentos.Remove(TipoDocumento);
        await _unitOfWork.SaveAsync();
        return NoContent();    
    }
}