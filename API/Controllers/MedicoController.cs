using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class MedicoController:BaseController{
    private readonly CitasCampusContext _context;    
    public MedicoController(CitasCampusContext context)=>_context = context;
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Medico>>> Get()=> await _context.Medicos.ToListAsync();
}