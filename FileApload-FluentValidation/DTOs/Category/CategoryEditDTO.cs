using Swashbuckle.AspNetCore.Annotations;

namespace FileApload_FluentValidation.DTOs.Category
{
    public class CategoryEditDTO
    {
        public string Name { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }
        public IFormFile? UploadImage { get; set; }

    }
}
