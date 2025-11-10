using Ecommerce.Core.Bases;
using MediatR;

namespace Ecommerce.Core.Product.Commands.Models
{
    public class UpdateProductCommand : IRequest<BaseResponse<bool>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Guid CategoryId { get; set; }
    }
}
