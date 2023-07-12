using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class EspecialidadController: BaseController{
    private readonly CitasCampusContext _context;
    public EspecialidadController(CitasCampusContext context)=>_context=context;
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Especialidad>>> Get(){
        return await _context.Especialidades.ToListAsync();
    }
    
}