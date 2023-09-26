using Assignment3Model.Models;
using Assignment3Model.Models.ViewModel;

namespace Assignment3.Services.ProductService
{
    public interface IProductService
    {
        List<Product> GetAllProduct();

        ProductVM ReturnProductVM();
        Product GetProduct(int productId);
        void CreateProduct(ProductVM productVM);

        void UpdateProduct(ProductVM productVM);

        void DeleteProduct(int productId);
    }
}
