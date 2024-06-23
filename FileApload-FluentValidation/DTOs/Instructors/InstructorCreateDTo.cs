using FileApload_FluentValidation.DTOs.Informations;
using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace FileApload_FluentValidation.DTOs.Instructors
{
    public class InstructorCreateDTo
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Field { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }
        public IFormFile UploadImage { get; set; }

        public class InstuructorCreateDTOValidator : AbstractValidator<InstructorCreateDTo>
        {
            public InstuructorCreateDTOValidator()
            {
                RuleFor(m => m.FullName).NotNull().WithMessage("Title PB-101 is required");
                RuleFor(m => m.Email).NotEmpty().NotNull();
                RuleFor(m => m.Address).NotEmpty().NotNull();
                RuleFor(m => m.Phone).NotEmpty().NotNull();
                RuleFor(m => m.Field).NotEmpty().NotNull();
               // RuleFor(m => m.Image).NotEmpty().NotNull();
            }
        }
    }
}
