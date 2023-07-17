using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class ConsultorioRepository : ICitasAPIEntity<Consultorio, int>
{
    private readonly CitasCampusContext _context;
    public ConsultorioRepository(CitasCampusContext context)=>_context = context;

    public void Add(Consultorio entity)=>_context.Set<Consultorio>().Add(entity);

    public void AddRange(ICollection<Consultorio> entities)=>_context.Set<Consultorio>().AddRange(entities);

    public IEnumerable<Consultorio> Find(Expression<Func<Consultorio, bool>> expression)=>_context.Set<Consultorio>().Where(expression);

    public async Task<ICollection<Consultorio>> GetAllAsync()=>await _context.Set<Consultorio>().ToListAsync();

    public async Task<Consultorio> GetByIdAsync(int id)=>(await _context.Set<Consultorio>().FindAsync(id))!;

    public void Remove(Consultorio entity)=>_context.Set<Consultorio>().Remove(entity);

    public void RemoveRange(ICollection<Consultorio> entities)=>_context.Set<Consultorio>().RemoveRange(entities);

    public void Update(Consultorio entity)=>_context.Set<Consultorio>().Update(entity);
    
}