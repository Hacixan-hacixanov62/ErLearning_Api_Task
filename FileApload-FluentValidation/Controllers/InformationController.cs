using FileApload_FluentValidation.DTOs.Informations;
using FileApload_FluentValidation.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileApload_FluentValidation.Controllers
{

    public class InformationController : BaseController
    {
        private readonly IInformarionService _informationService;
        public InformationController(IInformarionService informationService)
        {
            _informationService = informationService;
            
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] InformationCreateDTo request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _informationService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), request);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _informationService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromForm] int id)
        {
            await _informationService.GetByIdAsync(id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _informationService.DeleteAsync(id);
            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id , [FromForm] InformationEditDTo request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _informationService.EditAsync(id,request);
            return Ok();

        }



    }
}
