using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class MedicoRepository : ICitasAPIEntity<Medico, int>
{
    private readonly CitasCampusContext _context;
    public MedicoRepository(CitasCampusContext context)=>_context = context;

    public void Add(Medico entity)=>_context.Set<Medico>().Add(entity);

    public void AddRange(ICollection<Medico> entities)=>_context.Set<Medico>().AddRange(entities);

    public IEnumerable<Medico> Find(Expression<Func<Medico, bool>> expression)=>_context.Set<Medico>().Where(expression);

    public async Task<ICollection<Medico>> GetAllAsync()=>await _context.Set<Medico>().ToListAsync();

    public async Task<Medico> GetByIdAsync(int id)=>(await _context.Set<Medico>().FindAsync(id))!;

    public void Remove(Medico entity)=>_context.Set<Medico>().Remove(entity);

    public void RemoveRange(ICollection<Medico> entities)=>_context.Set<Medico>().RemoveRange(entities);

    public void Update(Medico entity)=>_context.Set<Medico>().Update(entity);
    
}