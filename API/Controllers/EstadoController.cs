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
}