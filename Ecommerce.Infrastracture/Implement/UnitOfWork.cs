using Ecommerce.Domain.Models;
using Ecommerce.Infrastracture.Data;
using Ecommerce.Infrastracture.Interface;
using Ecommerce.Infrastracture.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastracture.Implement
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository => new ProductRepository(_context);

        public ICategoryRepository CategoryRepository => new CategoryRepository(_context);

        public ICartItemRepository cartItemRepository => new CartItemRepository(_context);

        public Task<int> SaveChangesAsync()
        {
           return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

       
    }
}
