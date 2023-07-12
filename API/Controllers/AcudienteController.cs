using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class AcudienteController:BaseController{
    private readonly CitasCampusContext _context;    

    public AcudienteController(CitasCampusContext context){
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Acudiente>>> Get(){
        var nameVar = await _context.Acudientes.ToListAsync();
        return Ok(nameVar);
    }
}