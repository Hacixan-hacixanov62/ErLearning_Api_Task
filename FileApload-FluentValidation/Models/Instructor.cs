namespace FileApload_FluentValidation.Models
{
    public class Instructor:BaseEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Field { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string? Image { get; set; }

        //public List<InstructorSocial> InstructorSocials { get; set; }
        //public ICollection<Course> Courses { get; set; }
    }
}
