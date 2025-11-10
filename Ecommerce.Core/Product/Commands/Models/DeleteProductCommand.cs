using Ecommerce.Core.Bases;
using MediatR;

namespace Ecommerce.Core.Product.Commands.Models
{
    public class DeleteProductCommand : IRequest<BaseResponse<bool>>
    {
        public Guid ProductId { get; set; }

        public DeleteProductCommand(Guid Id)
        {
            this.ProductId = Id;
        }
    }
}
