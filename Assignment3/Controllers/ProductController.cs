using Assignment3Model.Models;
using Assignment3Model.Models.ViewModel;
using Assignment3.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;   
        }
   
        public IActionResult Index()
        {
            var products = _productService.GetAllProduct();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ProductVM productsVM = _productService.ReturnProductVM();
            return View(productsVM);
        }

        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            if (!ModelState.IsValid)
            {
                return View(productVM);
            }

            _productService.CreateProduct(productVM);
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Edit(int id)
        {
            ProductVM productsVM = _productService.ReturnProductVM();
            productsVM.Product = _productService.GetProduct(id);
            return View(productsVM);
        }

        [HttpPost]
        public IActionResult Edit(ProductVM productVM)
        {
            if (!ModelState.IsValid)
            {
                return View(productVM);
            }

            _productService.UpdateProduct(productVM);

            return RedirectToAction("Index", "Product");
        }

        [HttpDelete]
        [Route("Product/Delete/{itemId}")]
        public IActionResult Delete(int itemId)
        {
            _productService.DeleteProduct(itemId);
            return Json(new { success = true });
        }
    }
}
