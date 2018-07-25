using Microsoft.Extensions.DependencyInjection;
using Org.Visiontech.Optoplus.Dto.Entity.Product;
using VisiontechCommons;

namespace Org.Visiontech.Commons.Services
{

    public class ProductService : DeletableService<ProductDTO>, IDeletableService<ProductDTO>
    {

        static ProductService()
        {
            Container.services.AddSingleton<IDeletableService<ProductDTO>, ProductService>();
        }

        public ProductService() : base("product")
        {
        }

    }

}