using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class TipoDocumentoRepository : ICitasAPIEntity<TipoDocumento, int>
{
    private readonly CitasCampusContext _context;
    public TipoDocumentoRepository(CitasCampusContext context)=>_context = context;

    public void Add(TipoDocumento entity)=>_context.Set<TipoDocumento>().Add(entity);

    public void AddRange(ICollection<TipoDocumento> entities)=>_context.Set<TipoDocumento>().AddRange(entities);

    public IEnumerable<TipoDocumento> Find(Expression<Func<TipoDocumento, bool>> expression)=>_context.Set<TipoDocumento>().Where(expression);

    public async Task<ICollection<TipoDocumento>> GetAllAsync()=>await _context.Set<TipoDocumento>().ToListAsync();

    public async Task<TipoDocumento> GetByIdAsync(int id)=>(await _context.Set<TipoDocumento>().FindAsync(id))!;

    public void Remove(TipoDocumento entity)=>_context.Set<TipoDocumento>().Remove(entity);

    public void RemoveRange(ICollection<TipoDocumento> entities)=>_context.Set<TipoDocumento>().RemoveRange(entities);

    public void Update(TipoDocumento entity)=>_context.Set<TipoDocumento>().Update(entity);
    
}