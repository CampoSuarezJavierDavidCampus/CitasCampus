using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class AcudienteController:BaseController{

    private readonly IUnitOfWork _unitOfWork;
    public AcudienteController(IUnitOfWork unitOfWork)=> _unitOfWork = unitOfWork;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Acudiente>>> Get()=>Ok(await _unitOfWork.Acudientes.GetAllAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Acudiente>>> Get(int id)=>Ok(await _unitOfWork.Acudientes.GetByIdAsync(id));
}