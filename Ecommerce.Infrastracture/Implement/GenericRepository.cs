using Ecommerce.Infrastracture.Data;
using Ecommerce.Infrastracture.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastracture.Implement
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        #region Fields
        private readonly ApplicationContext _context;
        protected readonly DbSet<T> _dbSet;
        #endregion

        #region Constructor
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        #endregion

        #region Methods
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public void Delete(Guid Id)
        {
            var entity = _dbSet.Find(Id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        #endregion
    }
}
