using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Takim_B_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productService.GetAllAsync();
        }

        [HttpGet("getbyid")]
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productService.GetByIdAsync(id);
        }

        [HttpPost("add")]
        public void AddEntity(Product entity)
        {
            _productService.AddEntity(entity);
        }

        [HttpPut("update")]
        public void UpdateEntity(Product entity)
        {
            _productService.UpdateEntity(entity);
        }

        [HttpDelete("delete")]
        public void DeleteEntity(int id)
        {
            _productService.DeleteEntity(id);
        }

        [HttpGet("getbyname")]
        public Task<Product> GetByName(string name)
        {
            return _productService.GetByName(name);
        }

        [HttpGet("getproductdetail")]
        public async Task<List<ProductDetailDto>> GetProductDetail(string categoryName)
        {
            
            return await _productService.GetProductDetail(categoryName);
        }

        [HttpGet("getbybarcode")]
        public async Task<Product> GetByBarcode(long barcode)
        {
            return await _productService.GetByBarcode(barcode);
        }

        [HttpGet("getallproductdetail")]
        public Task<List<ProductDetailDto>> GetAllProductDetail()
        {
            return _productService.GetAllProductDetail();
        }
    }
}
