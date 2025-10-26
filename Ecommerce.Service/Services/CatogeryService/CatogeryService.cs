using Ecommerce.Domain.Models;
using Ecommerce.Infrastracture.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services.CatogeryService
{
    #region Interface
    public interface ICatogeryService
    {
        Task<IReadOnlyList<Category>> GetAllCategoriesAsync();
    }
    #endregion

    #region Implementation
    public class CatogeryService : ICatogeryService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public CatogeryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public async Task<IReadOnlyList<Category>> GetAllCategoriesAsync()
        {
            return await _unitOfWork.CategoryRepository.GetAllAsync();
        }
        #endregion
    }
    #endregion
}
