using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class GeneroController:BaseController{
    private readonly CitasCampusContext _context;    
    public GeneroController(CitasCampusContext context)=>_context = context;
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Genero>>> Get()=> await _context.Generos.ToListAsync();
}