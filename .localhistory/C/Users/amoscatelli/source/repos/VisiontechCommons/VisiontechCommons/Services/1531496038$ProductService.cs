using Org.Visiontech.Commons;
using Org.Visiontech.Optoplus.Dto.Entity.Product;
using Xamarin.Forms;

namespace Org.Visiontech.Commons
{

    public class ProductService : DeletableService<ProductDTO>, IDeletableService<ProductDTO>
    {

        public ProductService() : base("product")
        {
        }

    }

}