using Ecommerce.Core.Product.Queries.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Mapping
{
    public partial class Profiles
    {
        public void ConfigureProductQueryMapping()
        {
            CreateMap<Ecommerce.Domain.Models.Product, GetAllProductsResponse>()
                    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                    .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.StockQuantity));

            CreateMap<Ecommerce.Domain.Models.Product, GetProductByIdResponse>()
                    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                    .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.StockQuantity));
        }
        



    }
}
