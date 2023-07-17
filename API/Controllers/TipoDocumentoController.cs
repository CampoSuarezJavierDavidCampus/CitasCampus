using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class TipoDocumentoController:BaseController{
    
    private readonly IUnitOfWork _unitOfWork;
    public TipoDocumentoController(IUnitOfWork unitOfWork)=> _unitOfWork = unitOfWork;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoDocumento>>> Get()=>Ok(await _unitOfWork.TipoDocumentos.GetAllAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoDocumento>>> Get(int id)=> Ok(await _unitOfWork.TipoDocumentos.GetByIdAsync(id));
}