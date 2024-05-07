using System.Linq.Expressions;

namespace DAL.Repositories.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(string id);
        Task<T> GetByIdAsync(string id);
        IQueryable<T> GetAll();
        IQueryable<T> FindAll(Expression<Func<T, bool>> expression);
        IEnumerable<T> FindAllAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        T Add(T entity);
        Task<T> UpdateAsync(T entity);
        bool Delete(T entity);
        Task<List<T>> GetAllByListAsync(Expression<Func<T, bool>> expression);
        void UpdateRange(List<T> entity);

        void RemoveRange(List<T> entity);
    }
}
