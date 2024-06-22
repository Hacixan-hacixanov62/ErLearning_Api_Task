using FileApload_FluentValidation.DTOs.Abouts;
using FileApload_FluentValidation.DTOs.Category;

namespace FileApload_FluentValidation.Services.Interface
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryCreateDTO request);
        Task EditAsync(int id, CategoryEditDTO request);
        Task DeleteAsync(int id);
        Task<List<CategoryDTO>> GetAllAsync();
        Task<CategoryDTO> GetByIdAsync(int id);
    }
}
