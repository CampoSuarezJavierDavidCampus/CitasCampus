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
}