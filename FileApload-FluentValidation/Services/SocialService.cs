using AutoMapper;
using FileApload_FluentValidation.Data;
using FileApload_FluentValidation.DTOs.Socials;
using FileApload_FluentValidation.Models;
using FileApload_FluentValidation.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace FileApload_FluentValidation.Services
{
    public class SocialService:ISocialService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public SocialService(AppDbContext context,
                             IWebHostEnvironment env,
                             IMapper mapper )
        {
            _context = context;
            _env = env;
            _mapper = mapper;
            
        }

        public async Task Create(SocialCreateDTo data)
        {
            await _context.AddAsync(new Social
            {
                Name = data.Name,
                Icon = data.Icon
            });

            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }

        public async Task Edit( int id , SocialEditDTo data)
        {
            var existSlider = await _context.Socials.FindAsync(id);
            if (data.UploadIcon is not null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "img", existSlider.Icon);
                if (File.Exists(oldPath))
                    File.Delete(oldPath);

                string fileName = Guid.NewGuid().ToString() + "-" + data.UploadIcon.FileName;
                string newPath = Path.Combine(_env.WebRootPath, "img", fileName);

                using (FileStream stream = new(newPath, FileMode.Create))
                {
                    await data.UploadIcon.CopyToAsync(stream);
                }


                data.Icon = fileName;
            }


            _mapper.Map(data, existSlider);

            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Social>> GetAllAsync()
        {
            return await _context.Socials
                .OrderByDescending(m => m.Id)
                .ToListAsync();
        }

        public async Task<Social> GetById(int id)
        {
            return await _context.Socials.FindAsync(id);
        }
    }
}
