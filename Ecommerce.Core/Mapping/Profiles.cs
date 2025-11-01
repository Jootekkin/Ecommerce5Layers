using AutoMapper;
using Ecommerce.Core.Product.Queries.Results;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Mapping
{
    public partial class Profiles : Profile
    {
        public Profiles()
        {
            ConfigureProductQueryMapping();
        }
    }
}
