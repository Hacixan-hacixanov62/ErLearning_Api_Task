using System.ComponentModel.DataAnnotations.Schema;

namespace FileApload_FluentValidation.Models
{
    public class InstructorSocial
    {
        public int Id { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public int SocialId { get; set; }
        public Social Social { get; set; }
        public string Link { get; set; }
    }
}
