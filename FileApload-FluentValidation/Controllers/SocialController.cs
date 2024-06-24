using FileApload_FluentValidation.DTOs.Instructors;
using FileApload_FluentValidation.DTOs.Socials;
using FileApload_FluentValidation.Models;
using FileApload_FluentValidation.Services;
using FileApload_FluentValidation.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileApload_FluentValidation.Controllers
{

    public class SocialController : BaseController
    {
        private readonly ISocialService _socialService;

        public SocialController(ISocialService socialService)
        {
            _socialService = socialService;
            
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SocialCreateDTo request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _socialService.Create(request);
            return CreatedAtAction(nameof(Create), request);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _socialService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromForm] int id)
        {
            await _socialService.GetById(id);
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _socialService.Delete(id);
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] SocialEditDTo request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _socialService.Edit(id, request);
            return Ok();

        }


    }
}
