namespace FileApload_FluentValidation.Models
{
    public class Information:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}


//SoftDelete yazmagi yadan cixmasin BaseEntity
