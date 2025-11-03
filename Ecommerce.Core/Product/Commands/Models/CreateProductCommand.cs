using Ecommerce.Core.Bases;
using Ecommerce.Core.Product.Commands.Results;
using MediatR;

namespace Ecommerce.Core.Product.Commands.Models
{
    public class CreateProductCommand : IRequest<BaseResponse<CreateProductCommandResponse>>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid CategoryId { get; set; }
    }
}
