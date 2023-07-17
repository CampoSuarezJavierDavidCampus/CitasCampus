using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class CitaRepository : ICitasAPIEntity<Cita, int>
{
    private readonly CitasCampusContext _context;
    public CitaRepository(CitasCampusContext context)=>_context = context;

    public void Add(Cita entity)=>_context.Set<Cita>().Add(entity);

    public void AddRange(ICollection<Cita> entities)=>_context.Set<Cita>().AddRange(entities);

    public IEnumerable<Cita> Find(Expression<Func<Cita, bool>> expression)=>_context.Set<Cita>().Where(expression);

    public async Task<ICollection<Cita>> GetAllAsync()=>await _context.Set<Cita>().ToListAsync();

    public async Task<Cita> GetByIdAsync(int id)=>(await _context.Set<Cita>().FindAsync(id))!;

    public void Remove(Cita entity)=>_context.Set<Cita>().Remove(entity);

    public void RemoveRange(ICollection<Cita> entities)=>_context.Set<Cita>().RemoveRange(entities);

    public void Update(Cita entity)=>_context.Set<Cita>().Update(entity);
}
    