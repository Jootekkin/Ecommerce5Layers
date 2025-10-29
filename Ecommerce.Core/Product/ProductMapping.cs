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
        public void ConfigureProductMapping()
        {
            CreateMap<Ecommerce.Domain.Models.Product, GetProductByIdResponse>()
                    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                    .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.StockQuantity));


        }
        



    }
}
