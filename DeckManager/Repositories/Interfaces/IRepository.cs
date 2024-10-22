using System.Linq.Expressions;

namespace DeckManager.Repositories.Interfaces
{
    public interface IRepository<T>
    {
         IEnumerable<T>? GetAll();
         T? Get(Expression<Func<T, bool>> predicate);
         T? Post(T entity);
         T? Update(T entity);
         T? Delete(T entity);
    }
}
