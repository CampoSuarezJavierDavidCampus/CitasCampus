using System.Reflection.Emit;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class ConsultorioController:BaseController{
    private readonly CitasCampusContext _context;
    public ConsultorioController(CitasCampusContext context)
    {
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Consultorio>>> Get(){
        var nameVar = await _context.Consultorios.ToListAsync();
        return Ok(nameVar);
    }
}