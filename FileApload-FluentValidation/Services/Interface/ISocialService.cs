using FileApload_FluentValidation.DTOs.Socials;
using FileApload_FluentValidation.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FileApload_FluentValidation.Services.Interface
{
    public interface ISocialService
    {
        Task Create( SocialCreateDTo data);
        Task Edit(int id, SocialEditDTo data);
        Task Delete(int id);
        Task<Social> GetById(int id);

     
        Task<IEnumerable<Social>> GetAllAsync();


    }
}
