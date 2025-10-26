using Ecommerce.Infrastracture.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastracture.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductRepository ProductRepository { get; }
        public ICartItemRepository cartItemRepository { get; }
        public Task<int> SaveChangesAsync();
    }
}
