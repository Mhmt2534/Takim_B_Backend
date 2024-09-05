using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Takim_B_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var category = _categoryService.GetAllAsync().Result;
            return Ok(category);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;
            return Ok(category);
        }

        [HttpGet("getbyname")]
        public IActionResult GetByName(string name)
        {
            var category = _categoryService.GetByName(name).Result;
            return Ok(category);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Category category)
        {
            _categoryService.AddEntity(category);
            return Ok(category);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] Category category)
        {
            _categoryService.UpdateEntity(category);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            _categoryService.DeleteEntity(id);
            return NoContent();
        }


    }
}
