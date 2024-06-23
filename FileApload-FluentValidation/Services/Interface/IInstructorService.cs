using FileApload_FluentValidation.DTOs.Informations;
using FileApload_FluentValidation.DTOs.Instructors;
using FileApload_FluentValidation.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FileApload_FluentValidation.Services.Interface
{
    public interface IInstructorService
    {
        Task CreateAsync(InstructorCreateDTo data);
        Task EditAsync(int id, InstructorEditDto data);
        Task DeleteAsync(int id);
       // Task AddSocialAsync(int id, InstructorSocialAddDTo data);
        Task<List<InstructorDTo>> GetAllAsync();
        Task<InstructorDTo> GetByIdAsync(int id);

       // Task<Instructor> GetByIdWithSocialsAsync(int id);
       // Task DeleteInstructorSocialAsync(InstructorSocialDeleteDTo data);
        //Task<int> GetCountAsync();
        //Task<bool> ExistEmailAsync(string email);
        //Task<bool> ExistPhoneAsync(string phone);
    }
}
