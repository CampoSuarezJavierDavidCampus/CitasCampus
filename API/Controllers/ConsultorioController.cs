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
}