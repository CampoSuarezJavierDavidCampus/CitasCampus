using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class GeneroController:BaseController{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public GeneroController(IUnitOfWork unitOfWork, IMapper mapper){
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GeneroDto>>> Get(){
        var generos = await _unitOfWork.Generos.GetAllAsync();
        return Ok( _mapper.Map<List<GeneroDto>>(generos));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GeneroDto>>> Get(int id){
        var generos = await _unitOfWork.Generos.GetByIdAsync(id);
        return _mapper.Map<List<GeneroDto>>(generos);
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