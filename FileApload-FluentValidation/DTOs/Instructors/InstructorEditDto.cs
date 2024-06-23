using Swashbuckle.AspNetCore.Annotations;

namespace FileApload_FluentValidation.DTOs.Instructors
{
    public class InstructorEditDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Field { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }
        //public List<InstructorSocialDTo> InstructorSocials { get; set; }
        public IFormFile UploadImage { get; set; }
    }
}
