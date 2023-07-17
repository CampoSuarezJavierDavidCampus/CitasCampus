using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class EstadoRepository : ICitasAPIEntity<Estado, int>
{
    private readonly CitasCampusContext _context;
    public EstadoRepository(CitasCampusContext context)=>_context = context;

    public void Add(Estado entity)=>_context.Set<Estado>().Add(entity);

    public void AddRange(ICollection<Estado> entities)=>_context.Set<Estado>().AddRange(entities);

    public IEnumerable<Estado> Find(Expression<Func<Estado, bool>> expression)=>_context.Set<Estado>().Where(expression);

    public async Task<ICollection<Estado>> GetAllAsync()=>await _context.Set<Estado>().ToListAsync();

    public async Task<Estado> GetByIdAsync(int id)=>(await _context.Set<Estado>().FindAsync(id))!;

    public void Remove(Estado entity)=>_context.Set<Estado>().Remove(entity);

    public void RemoveRange(ICollection<Estado> entities)=>_context.Set<Estado>().RemoveRange(entities);

    public void Update(Estado entity)=>_context.Set<Estado>().Update(entity);
    
}