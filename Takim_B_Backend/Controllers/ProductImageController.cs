using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Takim_B_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private IProductImageService _productImageService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductImageController(IProductImageService productImageService, IWebHostEnvironment webHostEnvironment)
        {
            _productImageService = productImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getall")]
        public async Task<IEnumerable<ProductImage>> GetAllAsync()
        {
            return await _productImageService.GetAllAsync();
        }

        [HttpGet("getbyid")]
        public async Task<ProductImage> GetByIdAsync(int id)
        {
            return await _productImageService.GetByIdAsync(id);
        }

        [HttpPost("add")]
        public void AddEntity([FromForm] IFormFile file, [FromForm] ProductImage entity)
        {
            _productImageService.AddEntity(file, entity);
        }

        [HttpPut("update")]
        public void UpdateEntity([FromForm] IFormFile file, [FromForm] ProductImage entity)
        {
            _productImageService.UpdateEntity(file, entity);
        }

        [HttpPost("delete")]
        public void DeleteImage(ProductImage productImage)
        {
            var productDeleteImage = _productImageService.GetByIdAsync(productImage.Id).Result;

            _productImageService.DeleteImage(productDeleteImage);
        }

        [HttpGet("getbyproductid")]
        public async Task<ProductImage> GetByProductId(int id)
        {
            var res= await _productImageService.GetByProductId(id);
            if (res != null)
            {
                return res;
            }
            return null;

        }


        [HttpGet("GetProductImage/{fileName}")]
        public IActionResult GetProductImage(string fileName)
        {
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", "ProductImages", fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var image = System.IO.File.OpenRead(filePath);
            return File(image, "image/jpeg"); // veya "image/png", resim formatına bağlı olarak
        }


    }
}
