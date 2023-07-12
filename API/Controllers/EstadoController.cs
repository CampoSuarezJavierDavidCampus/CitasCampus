using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class EstadoController:BaseController{
    private readonly CitasCampusContext _context;
    public EstadoController(CitasCampusContext context)=>_context = context;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Estado>>> Get(){
        return await _context.Estados.ToListAsync();
    }
        
}