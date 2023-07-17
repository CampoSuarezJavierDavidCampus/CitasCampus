using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class UsuarioController:BaseController{
    
    private readonly IUnitOfWork _unitOfWork;
    public UsuarioController(IUnitOfWork unitOfWork)=> _unitOfWork = unitOfWork;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Usuario>>> Get()=>Ok(await _unitOfWork.Usuarios.GetAllAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Usuario>>> Get(int id)=> Ok(await _unitOfWork.Usuarios.GetByIdAsync(id));
}