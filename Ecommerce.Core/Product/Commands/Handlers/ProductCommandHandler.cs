using AutoMapper;
using Ecommerce.Core.Bases;
using Ecommerce.Core.Product.Commands.Models;
using Ecommerce.Core.Product.Commands.Results;
using Ecommerce.Service.Services.ProductService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Product.Commands.Handlers
{
    public class ProductCommandHandler : ResponseHandler,
                                         IRequestHandler<CreateProductCommand, BaseResponse<CreateProductCommandResponse>>
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
            try
            {
                var newProduct = mapper.Map<Domain.Models.Product>(request);

                 createdProduct = await productService.CreateProductAsync(newProduct);
            }
            catch (Exception ex)
            {
                return HandleException<CreateProductCommandResponse>(ex.Message, "Error creating new product");
            }
            return Success(mapper.Map<CreateProductCommandResponse>(createdProduct), "Product created successfully");
        }


        #endregion

    }
}
