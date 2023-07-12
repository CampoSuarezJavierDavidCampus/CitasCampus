using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class UsuarioController:BaseController{
    private readonly CitasCampusContext _context;    
    public UsuarioController(CitasCampusContext context)=>_context = context;
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Usuario>>> Get()=> await _context.Usuarios.ToListAsync();
}