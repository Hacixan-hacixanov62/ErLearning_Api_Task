using AutoMapper;
using FileApload_FluentValidation.Data;
using FileApload_FluentValidation.DTOs.Informations;
using FileApload_FluentValidation.DTOs.Sliders;
using FileApload_FluentValidation.Models;
using FileApload_FluentValidation.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace FileApload_FluentValidation.Services
{
    public class InformationService : IInformarionService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public InformationService(AppDbContext context,
                                  IWebHostEnvironment env,
                                  IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;
            
        }

        public async Task CreateAsync(InformationCreateDTo request)
        {
            string fileName = $"{Guid.NewGuid()}-{request.UploadImage.FileName}";

            string path = Path.Combine(_env.WebRootPath, "img", fileName);

            using (FileStream stream = new(path, FileMode.Create))
            {
                await request.UploadImage.CopyToAsync(stream);
            }

            request.Image = fileName;

            await _context.Informations.AddAsync(_mapper.Map<Information>(request));

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {

            var existSlider = await _context.Informations.FindAsync(id);
            string path = Path.Combine(_env.WebRootPath, "img", existSlider.Image);

            if (File.Exists(path))
                File.Delete(path);

            _context.Informations.Remove(existSlider);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, InformationEditDTo request)
        {
            var existSlider = await _context.Informations.FindAsync(id);
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

        public async Task<List<InformationDTo>> GetAllAsync()
        {
            return  _mapper.Map<List<InformationDTo>>(await _context.Informations.AsTracking().ToListAsync());

        }

        public async Task<InformationDTo> GetByIdAsync(int id)
        {
            return _mapper.Map<InformationDTo>(await _context.Informations.AsTracking().FirstOrDefaultAsync(m => m.Id == id));

        }
    }
}
