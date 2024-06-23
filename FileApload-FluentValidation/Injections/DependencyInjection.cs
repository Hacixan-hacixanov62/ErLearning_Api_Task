using FileApload_FluentValidation.DTOs.Abouts;
using FileApload_FluentValidation.DTOs.Category;
using FileApload_FluentValidation.DTOs.Informations;
using FileApload_FluentValidation.DTOs.Instructors;
using FileApload_FluentValidation.DTOs.Sliders;
using FileApload_FluentValidation.Helpers;
using FileApload_FluentValidation.Services;
using FileApload_FluentValidation.Services.Interface;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using static FileApload_FluentValidation.DTOs.Instructors.InstructorCreateDTo;

namespace FileApload_FluentValidation.Injections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddFluentValidationAutoValidation(config=>
            {
                config.DisableDataAnnotationsValidation = true;
            });

            //Slider
            services.AddScoped<IValidator<SliderCreateDTo>, SliderCreateDToValidator>();

            services.AddScoped<ISliderService, SliderService>();

            //Information
            services.AddScoped<IInformarionService, InformationService>();

            services.AddScoped<IValidator<InformationCreateDTo>, InformationCreateDToValidator>();

            //About
            services.AddScoped<IAboutService, AboutService>();

            services.AddScoped<IValidator<AboutCreateDTo>, AboutCreateDToValidator>();

            //Category
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IValidator<CategoryCreateDTO>, CategoryCreateDTOValidator>();

            //Instructor
            services.AddScoped<IInstructorService, InstructorService>();

            services.AddScoped<IValidator<InstructorCreateDTo>, InstuructorCreateDTOValidator>();


            return services;
        }

    }
}
