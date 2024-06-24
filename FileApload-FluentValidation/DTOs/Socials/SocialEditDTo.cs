using Swashbuckle.AspNetCore.Annotations;

namespace FileApload_FluentValidation.DTOs.Socials
{
    public class SocialEditDTo
    {
        public string Name { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? Icon { get; set; }
        public IFormFile UploadIcon { get; set; }
    }
}
