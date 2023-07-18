using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class GeneroRepository : ICitasAPIEntity<Genero, int>
{
    private readonly CitasCampusContext _context;
    public GeneroRepository(CitasCampusContext context)=>_context = context;

    public void Add(Genero entity)=>_context.Set<Genero>().Add(entity);

    public void AddRange(ICollection<Genero> entities)=>_context.Set<Genero>().AddRange(entities);

    public IEnumerable<Genero> Find(Expression<Func<Genero, bool>> expression)=>_context.Set<Genero>().Where(expression);

    public async Task<ICollection<Genero>> GetAllAsync()
    {
        return await _context.Generos.Include(g => g.Usuarios).ToListAsync();
    }

    public async Task<Genero> GetByIdAsync(int id){
        return (await _context.Generos
            .Include(g => g.Usuarios)
            .FirstOrDefaultAsync(g => g.Id == id))!;
    }

    public void Remove(Genero entity)=>_context.Set<Genero>().Remove(entity);

    public void RemoveRange(ICollection<Genero> entities)=>_context.Set<Genero>().RemoveRange(entities);

    public void Update(Genero entity)=>_context.Set<Genero>().Update(entity);
    
}