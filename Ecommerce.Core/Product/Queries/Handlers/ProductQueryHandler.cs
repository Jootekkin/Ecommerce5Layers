using AutoMapper;
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
    public class ProductQueryHandler : IRequestHandler<GetAllProductsQuery, IReadOnlyList<GetAllProductsResponse>>
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
        public async Task<IReadOnlyList<GetAllProductsResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IReadOnlyList<GetAllProductsResponse>>(await _productService.GetAllProductsAsync());
        }
        #endregion
    }
}
