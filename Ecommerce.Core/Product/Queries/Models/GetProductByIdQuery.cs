using Ecommerce.Core.Bases;
using Ecommerce.Core.Product.Queries.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Product.Queries.Models
{
    public class GetProductByIdQuery : IRequest<BaseResponse<GetProductByIdResponse>>
    {
        public GetProductByIdQuery(Guid id)
        {
            this.ProductId = id;
        }
        public Guid ProductId { get; set; }
    }
}
