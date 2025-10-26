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
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
    #endregion

    #region Implementation
    internal class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext context) : base(context)
        {
        }
    }
    #endregion
}
