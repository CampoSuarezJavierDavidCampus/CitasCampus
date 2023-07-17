using System.Linq.Expressions;
namespace Core.Interfaces;

public interface ICitasAPIEntity<TEntity,T_ID>
{
    Task<TEntity> GetByIdAsync(T_ID id);
    Task<ICollection<TEntity>> GetAllAsync();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
    void Add(TEntity entity);
    void AddRange(ICollection<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(ICollection<TEntity> entities);
    void Update(TEntity entity);

}