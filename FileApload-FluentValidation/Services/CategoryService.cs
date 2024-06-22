using AutoMapper;
using FileApload_FluentValidation.Data;
using FileApload_FluentValidation.DTOs.Abouts;
using FileApload_FluentValidation.DTOs.Category;
using FileApload_FluentValidation.Models;
using FileApload_FluentValidation.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace FileApload_FluentValidation.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public CategoryService(AppDbContext context,
                               IWebHostEnvironment env,
                               IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;
            
        }

        public async Task CreateAsync(CategoryCreateDTO request)
        {
            string fileName = $"{Guid.NewGuid()}-{request.UploadImage.FileName}";

            string path = Path.Combine(_env.WebRootPath, "img", fileName);

            using (FileStream stream = new(path, FileMode.Create))
            {
                await request.UploadImage.CopyToAsync(stream);
            }

            request.Image = fileName;

            await _context.Categories.AddAsync(_mapper.Map<Category>(request));

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existSlider = await _context.Categories.FindAsync(id);
            string path = Path.Combine(_env.WebRootPath, "img", existSlider.Image);
            if(File.Exists(path))
                File.Delete(path);

            _context.Categories.Remove(existSlider);
            await _context.SaveChangesAsync();

        }

        public async Task EditAsync(int id, CategoryEditDTO request)
        {
            var existSlider = await _context.Categories.FindAsync(id);
            if (request.UploadImage is not null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "img", existSlider.Image);
                if (File.Exists(oldPath))
                    File.Delete(oldPath);

                string fileName = Guid.NewGuid().ToString() + "-" + request.UploadImage.FileName;
                string newPath = Path.Combine(_env.WebRootPath, "img", fileName);

                using (FileStream stream = new(newPath, FileMode.Create))
                {
                    await request.UploadImage.CopyToAsync(stream);
                }


                request.Image = fileName;
            }

            _mapper.Map(request, existSlider);

            await _context.SaveChangesAsync();

        }

        public async Task<List<CategoryDTO>> GetAllAsync()
        {
            return _mapper.Map<List<CategoryDTO>>(await _context.Categories.AsTracking().ToListAsync());

        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {

            return _mapper.Map<CategoryDTO>(await _context.Categories.AsTracking().FirstOrDefaultAsync(m => m.Id == id));

        }
    }
}
