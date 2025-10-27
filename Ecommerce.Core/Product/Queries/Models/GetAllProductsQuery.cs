using Ecommerce.Core.Product.Queries.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Product.Queries.Models
{
    public class GetAllProductsQuery : IRequest<IReadOnlyList<GetAllProductsResponse>>
    {
    }
}
