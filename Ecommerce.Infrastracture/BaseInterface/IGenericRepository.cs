namespace Ecommerce.Infrastracture.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Delete(Guid Id);

    }
}
