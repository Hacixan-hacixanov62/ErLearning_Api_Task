using FileApload_FluentValidation.DTOs.Sliders;
using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace FileApload_FluentValidation.DTOs.Informations
{
    public class InformationCreateDTo
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; } 
        public IFormFile UploadImage { get; set; }
    }

    public class InformationCreateDToValidator : AbstractValidator<InformationCreateDTo>
    {
        public InformationCreateDToValidator()
        {
            RuleFor(m => m.Title).NotNull().WithMessage("Title PB-101 is required");
            RuleFor(m => m.Description).NotEmpty().NotNull();
        }
    }
}
