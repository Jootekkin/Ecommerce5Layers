using AutoMapper;
using Ecommerce.Core.Bases;
using Ecommerce.Core.Product.Queries.Models;
using Ecommerce.Core.Product.Queries.Results;
using Ecommerce.Service.Services.ProductService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Product.Queries.Handlers
{
    public class ProductQueryHandler : ResponseHandler, IRequestHandler<GetAllProductsQuery,BaseResponse<IReadOnlyList<GetAllProductsResponse>>>
    {
        #region Fields
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ProductQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<BaseResponse<IReadOnlyList<GetAllProductsResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllProductsAsync();

            if (products == null || !products.Any())
            {
                return BadRequest<IReadOnlyList<GetAllProductsResponse>>("No products found.");
            }

            var mappedProducts = _mapper.Map<IReadOnlyList<GetAllProductsResponse>>(products);

            return Success(mappedProducts);
        }
        #endregion
    }
}
