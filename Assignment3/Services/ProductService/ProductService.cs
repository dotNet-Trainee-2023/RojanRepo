using Assignment3.Data;
using Assignment3.Models;
using Assignment3.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Assignment3.Services.ProductService
{
    public class ProductService:IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public Product GetProduct(int productId)
        {
            Product? product = _context.Products.Find(productId);
            if (product != null)
            {
                return product;
            }
            return null;
        }
        public List<Product> GetAllProduct()
        {

            return _context.Products
                .Include(p => p.Category)
                .ToList();
        }

        public void CreateProduct(ProductVM productVM)
        {
            _context.Products.Add(productVM.Product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int itemId)
        {
            Product? product = GetProduct(itemId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public void UpdateProduct(ProductVM productVM)
        {
            var data = _context.Products.Find(productVM.Product.Id);
            if (data != null)
            {
                data.Name = productVM.Product.Name;
                data.Price = productVM.Product.Price;
                data.CategoryId = productVM.Product.CategoryId;
                _context.Products.Update(data);
                _context.SaveChanges();
            }
        }

        public ProductVM ReturnProductVM()
        {
            ProductVM productVM = new()
            {
                CategoryList = _context.Categories.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            return productVM;
        }
    }
}
