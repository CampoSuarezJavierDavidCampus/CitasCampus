using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class EspecialidadRepository : ICitasAPIEntity<Especialidad, int>
{
    private readonly CitasCampusContext _context;
    public EspecialidadRepository(CitasCampusContext context)=>_context = context;

    public void Add(Especialidad entity)=>_context.Set<Especialidad>().Add(entity);

    public void AddRange(ICollection<Especialidad> entities)=>_context.Set<Especialidad>().AddRange(entities);

    public IEnumerable<Especialidad> Find(Expression<Func<Especialidad, bool>> expression)=>_context.Set<Especialidad>().Where(expression);

    public async Task<ICollection<Especialidad>> GetAllAsync()=>await _context.Set<Especialidad>().ToListAsync();

    public async Task<Especialidad> GetByIdAsync(int id)=>(await _context.Set<Especialidad>().FindAsync(id))!;

    public void Remove(Especialidad entity)=>_context.Set<Especialidad>().Remove(entity);

    public void RemoveRange(ICollection<Especialidad> entities)=>_context.Set<Especialidad>().RemoveRange(entities);

    public void Update(Especialidad entity)=>_context.Set<Especialidad>().Update(entity);
    
}