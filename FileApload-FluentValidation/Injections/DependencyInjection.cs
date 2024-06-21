using FileApload_FluentValidation.DTOs.Sliders;
using FileApload_FluentValidation.Services;
using FileApload_FluentValidation.Services.Interface;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;

namespace FileApload_FluentValidation.Injections
{
    public class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation(config:FluentValidationAutoValidationConfiguration =>
            {
                config.DisableDataAnnotationsValiolation = true;
            });

            services.AddScoped<IValidator<SliderCreateDTo>, SliderCreateDToValidator>();
            services.AddScoped<ISliderService, SliderService>();

            return services;
        }

    }
}
