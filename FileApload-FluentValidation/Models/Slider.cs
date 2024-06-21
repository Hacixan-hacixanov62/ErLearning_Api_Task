using System.ComponentModel.DataAnnotations;

namespace FileApload_FluentValidation.Models
{
    public class Slider:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
