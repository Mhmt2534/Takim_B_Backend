using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Takim_B_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }


        [HttpGet("getall")]
        public async Task<IEnumerable<Cart>> GetAllAsync()
        {
            return await _cartService.GetAllAsync();
        }


        [HttpGet("getbyid")]
        public async Task<Cart> GetByIdAsync(int id)
        {
            return await _cartService.GetByIdAsync(id);
        }

        [HttpPost("add")]
        public void AddEntity(Cart entity)
        {
            _cartService.AddEntity(entity);
        }

        [HttpPut("update")]
        public void UpdateEntity(Cart entity)
        {
            _cartService.UpdateEntity(entity);
        }

        [HttpDelete("delete")]
        public void DeleteEntity(int id)
        {
            _cartService.DeleteEntity(id);
        }

        [HttpGet("getbyproductid")]
        public async Task<Cart> GetByProductId(int id)
        {
            return await _cartService.GetByProductId(id);
        }

    }
}
