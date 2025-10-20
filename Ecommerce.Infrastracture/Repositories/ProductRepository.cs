using Ecommerce.Domain.Models;
using Ecommerce.Infrastracture.Data;
using Ecommerce.Infrastracture.Implement;
using Ecommerce.Infrastracture.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastracture.Repositories
{
    #region Interface
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
    #endregion

    #region Implementation
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }
    }
    #endregion

}
