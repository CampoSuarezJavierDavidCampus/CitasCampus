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
}