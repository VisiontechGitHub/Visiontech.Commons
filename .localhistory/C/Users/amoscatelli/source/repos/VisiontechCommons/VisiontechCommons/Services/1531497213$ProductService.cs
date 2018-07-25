using Org.Visiontech.Optoplus.Dto.Entity.Product;

namespace Org.Visiontech.Commons.Services
{

    public class ProductService : DeletableService<ProductDTO>, IDeletableService<ProductDTO>
    {

        static ProductService()
        {
            Container.services.AddSingleton<IDeletableService<ProductDTO>, PersonService>();
        }

        public ProductService() : base("product")
        {
        }

    }

}