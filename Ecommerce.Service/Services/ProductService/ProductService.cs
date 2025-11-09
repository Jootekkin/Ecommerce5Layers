using Ecommerce.Domain.Models;
using Ecommerce.Infrastracture.Interface;

namespace Ecommerce.Service.Services.ProductService
{
    #region Interface
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(Guid productId);
        Task<Product> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(Guid productId);
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

        public async Task<Product?> GetProductByIdAsync(Guid productId)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(productId);
            if (product != null)
            {
                return product;
            }
            return null;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            _unitOfWork.ProductRepository.Update(product);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            _unitOfWork.ProductRepository.Delete(productId);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion
    }
    #endregion
}
