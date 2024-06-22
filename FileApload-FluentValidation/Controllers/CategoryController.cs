using FileApload_FluentValidation.DTOs.Abouts;
using FileApload_FluentValidation.DTOs.Category;
using FileApload_FluentValidation.Services;
using FileApload_FluentValidation.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileApload_FluentValidation.Controllers
{
   
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _categoryService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), request);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromForm] int id)
        {
            await _categoryService.GetByIdAsync(id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] CategoryEditDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _categoryService.EditAsync(id, request);
            return Ok();

        }
    }
}
