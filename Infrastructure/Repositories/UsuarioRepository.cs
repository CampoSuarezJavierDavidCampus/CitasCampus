using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class UsuarioRepository : ICitasAPIEntity<Usuario, int>
{
    private readonly CitasCampusContext _context;
    public UsuarioRepository(CitasCampusContext context)=>_context = context;

    public void Add(Usuario entity)=>_context.Set<Usuario>().Add(entity);

    public void AddRange(ICollection<Usuario> entities)=>_context.Set<Usuario>().AddRange(entities);

    public IEnumerable<Usuario> Find(Expression<Func<Usuario, bool>> expression)=>_context.Set<Usuario>().Where(expression);

    public async Task<ICollection<Usuario>> GetAllAsync()=>await _context.Set<Usuario>().ToListAsync();

    public async Task<Usuario> GetByIdAsync(int id)=>(await _context.Set<Usuario>().FindAsync(id))!;

    public void Remove(Usuario entity)=>_context.Set<Usuario>().Remove(entity);

    public void RemoveRange(ICollection<Usuario> entities)=>_context.Set<Usuario>().RemoveRange(entities);

    public void Update(Usuario entity)=>_context.Set<Usuario>().Update(entity);
    
}