using Ecommerce.Core.Product.Commands.Models;
using Ecommerce.Core.Product.Commands.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Mapping
{
    public partial class Profiles
    {
        public void ConfigureProductCommandMapping()
        {
            CreateMap<CreateProductCommand, Domain.Models.Product>();

            CreateMap<Domain.Models.Product, CreateProductCommandResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.StockQuantity))
                ;
        }
    }
}
