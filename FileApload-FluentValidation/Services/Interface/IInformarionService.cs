using FileApload_FluentValidation.DTOs.Informations;
using FileApload_FluentValidation.DTOs.Sliders;

namespace FileApload_FluentValidation.Services.Interface
{
    public interface IInformarionService
    {
        Task CreateAsync(InformationCreateDTo request);
        Task EditAsync(int id, InformationEditDTo request);
        Task DeleteAsync(int id);
        Task<List<InformationDTo>> GetAllAsync();
        Task<InformationDTo> GetByIdAsync(int id);
    }
}
