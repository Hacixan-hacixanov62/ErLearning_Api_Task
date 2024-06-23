using FileApload_FluentValidation.DTOs.Instructors;
using FileApload_FluentValidation.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileApload_FluentValidation.Controllers
{
    public class InstructorController :BaseController
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] InstructorCreateDTo request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _instructorService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), request);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _instructorService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromForm] int id)
        {
            await _instructorService.GetByIdAsync(id);
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete( [FromQuery] int id)
        {
            await _instructorService.DeleteAsync(id);
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] InstructorEditDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _instructorService.EditAsync(id, request);
            return Ok();
        }

    }
}
