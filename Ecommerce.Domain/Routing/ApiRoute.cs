using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Routing
{
    public class ApiRoute
    {
        const string Base = "api/";
        const string Version = "v1/";

        public static class Products
        {
            public const string GetAllProducts = Base + Version + "Products";
            public const string GetProductById = Base + Version + "Products/Product/{id}";
            public const string CreateProduct  = Base + Version + "Products/CreateProduct";
            public const string UpdateProduct  = Base + Version + "Products/UpdateProduct";
            public const string DeleteProduct  = Base + Version + "Products/DeleteProduct/{id}";
        }
    }
}
