using Ecommerce.Domain.Models;
using Ecommerce.Infrastracture.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services.ProductService
{
    #region Interface
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(Guid productId);
    }
    #endregion

    #region Implementation
    public class ProductService : IProductService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public async Task<IReadOnlyList<Product>> GetAllProductsAsync()
        {
            return await _unitOfWork.ProductRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            return await _unitOfWork.ProductRepository.GetByIdAsync(productId);
        }
        #endregion
    }
    #endregion
}
