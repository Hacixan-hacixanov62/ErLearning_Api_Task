using Swashbuckle.AspNetCore.Annotations;

namespace FileApload_FluentValidation.DTOs.Informations
{
    public class InformationEditDTo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }
        public IFormFile? UploadImage { get; set; }
    }
}
