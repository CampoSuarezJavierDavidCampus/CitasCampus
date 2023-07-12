using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;    
public class CitaController: BaseController{
    private readonly CitasCampusContext _context;
    public CitaController(CitasCampusContext context){
        _context = context;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Cita>>> Get(){
        var nameVar = await _context.Citas.ToListAsync();
        return Ok(nameVar);
    }
    
}