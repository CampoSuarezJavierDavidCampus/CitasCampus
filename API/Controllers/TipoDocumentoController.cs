using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
public class TipoDocumentoController:BaseController{
    private readonly CitasCampusContext _context;    
    public TipoDocumentoController(CitasCampusContext context)=>_context = context;
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoDocumento>>> Get()=> Ok(await _context.TipoDocumentos.ToListAsync());
}