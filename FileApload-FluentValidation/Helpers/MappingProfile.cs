using AutoMapper;
using FileApload_FluentValidation.DTOs.Abouts;
using FileApload_FluentValidation.DTOs.Category;
using FileApload_FluentValidation.DTOs.Informations;
using FileApload_FluentValidation.DTOs.Instructors;
using FileApload_FluentValidation.DTOs.Sliders;
using FileApload_FluentValidation.Models;

namespace FileApload_FluentValidation.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Slider
            CreateMap<Slider, SliderDTo>();
            CreateMap<SliderCreateDTo, Slider>();
            CreateMap<SliderEditDTo, Slider>().ForMember(dest => dest.Image, opt => opt.Condition(src => (src.Image is null)));
                
            //    ForPath(
            //  m => m.Image,
            //    opt =>
            //    {
            //        opt.Condition(

            //            s => s.Destination.Image != null
            //        );
            //        opt.MapFrom(s=>s.Image);
            //    }
            //); 


            //Information
            CreateMap<Information, InformationDTo> ();
            CreateMap<InformationCreateDTo, Information>();
            CreateMap<InformationEditDTo, Information>().ForMember(dest => dest.Image, opt => opt.Condition(src => (src.Image is null)));


            //About
            CreateMap<About, AboutDTo> ();
            CreateMap <AboutCreateDTo, About>();
            CreateMap<AboutEditDTo, About>().ForMember(dest => dest.Image, opt => opt.Condition(src => (src.Image is null)));

            //Category
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<CategoryEditDTO, Category>().ForMember(dest => dest.Image, opt => opt.Condition(src => (src.Image is null)));

            //Instructor
            CreateMap<Instructor, InstructorDTo> ();
            CreateMap<InstructorCreateDTo, Instructor>();
            CreateMap<InstructorEditDto, Instructor>().ForMember(dest => dest.Image, opt => opt.Condition(src => (src.Image is null)));


        }

    }
}
