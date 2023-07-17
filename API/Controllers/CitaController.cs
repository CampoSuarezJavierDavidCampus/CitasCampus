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
    
}