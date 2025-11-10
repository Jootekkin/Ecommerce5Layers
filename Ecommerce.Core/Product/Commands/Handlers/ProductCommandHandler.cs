using AutoMapper;
using Ecommerce.Core.Bases;
using Ecommerce.Core.Product.Commands.Models;
using Ecommerce.Core.Product.Commands.Results;
using Ecommerce.Service.Services.ProductService;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Core.Product.Commands.Handlers
{
    public class ProductCommandHandler : ResponseHandler,
                                         IRequestHandler<CreateProductCommand, BaseResponse<CreateProductCommandResponse>>,
                                         IRequestHandler<UpdateProductCommand, BaseResponse<bool>>,
                                         IRequestHandler<DeleteProductCommand, BaseResponse<bool>>
    {

        #region Fields
        private readonly IProductService productService;
        private readonly IMapper mapper;
        #endregion

        #region Constructor
        public ProductCommandHandler(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<BaseResponse<CreateProductCommandResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var createdProduct = new Domain.Models.Product();

            var newProduct = mapper.Map<Domain.Models.Product>(request);

            createdProduct = await productService.CreateProductAsync(newProduct);

            //createdProduct.Category = await categoryService.GetCategoryByIdAsync(createdProduct.CategoryId);

            return Success(mapper.Map<CreateProductCommandResponse>(createdProduct), "Product created successfully");
        }

        public async Task<BaseResponse<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var result = false;
            try
            {
                var updatedProduct = mapper.Map<Domain.Models.Product>(request);
                result = await productService.UpdateProductAsync(updatedProduct);
            }
            catch (DbUpdateException ex)
            {

                throw new Exception($"Database update product error: {ex.Message} ");
            }
            return result
                ? Success(true, "Product updated successfully")
                : Failed<bool>("Failed to update product");
        }

        public async Task<BaseResponse<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var result = await productService.DeleteProductAsync(request.ProductId);
            return result
                ? Success(true, "Product deleted successfully")
                : Failed<bool>("Failed to delete product");
        }


        #endregion

    }
}
