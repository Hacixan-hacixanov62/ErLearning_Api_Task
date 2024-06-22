using FileApload_FluentValidation.DTOs.Abouts;
using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace FileApload_FluentValidation.DTOs.Category
{
    public class CategoryCreateDTO
    {
        public string Name { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }
        public IFormFile UploadImage { get; set; }
    }

    public class CategoryCreateDTOValidator : AbstractValidator<CategoryCreateDTO>
    {
        public CategoryCreateDTOValidator()
        {
            RuleFor(m => m.Name).NotNull().WithMessage("Title PB-101 is required");
        }
    }
}
