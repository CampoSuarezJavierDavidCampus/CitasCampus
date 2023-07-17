using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class AcudienteRepository : ICitasAPIEntity<Acudiente, int>
{
    private readonly CitasCampusContext _context;
    public AcudienteRepository(CitasCampusContext context)=>_context = context;

    public void Add(Acudiente entity)=>_context.Set<Acudiente>().Add(entity);

    public void AddRange(ICollection<Acudiente> entities)=>_context.Set<Acudiente>().AddRange(entities);

    public IEnumerable<Acudiente> Find(Expression<Func<Acudiente, bool>> expression)=>_context.Set<Acudiente>().Where(expression);

    public async Task<ICollection<Acudiente>> GetAllAsync()=>await _context.Set<Acudiente>().ToListAsync();

    public async Task<Acudiente> GetByIdAsync(int id)=>(await _context.Set<Acudiente>().FindAsync(id))!;

    public void Remove(Acudiente entity)=>_context.Set<Acudiente>().Remove(entity);

    public void RemoveRange(ICollection<Acudiente> entities)=>_context.Set<Acudiente>().RemoveRange(entities);

    public void Update(Acudiente entity)=>_context.Set<Acudiente>().Update(entity);
    
}