using AutoMapper;
using FileApload_FluentValidation.Data;
using FileApload_FluentValidation.DTOs.Informations;
using FileApload_FluentValidation.DTOs.Instructors;
using FileApload_FluentValidation.Models;
using FileApload_FluentValidation.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace FileApload_FluentValidation.Services
{
    public class InstructorService:IInstructorService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public InstructorService(AppDbContext context,
                                 IWebHostEnvironment env,
                                 IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;
            
        }

        //public async Task AddSocialAsync(int id, InstructorSocialAddDTo data)
        //{
        //    await _context.InstructorSocials.AddAsync(new InstructorSocial
        //    {
        //        InstructorId = id,
        //        SocialId = (int)data.SocialId,
        //        Link = data.SocialLink
        //    });

        //    await _context.SaveChangesAsync();
        //}

        public async Task CreateAsync(InstructorCreateDTo data)
        {
            string fileName = $"{Guid.NewGuid()}-{data.UploadImage.FileName}";

            string path = Path.Combine(_env.WebRootPath, "img", fileName);

            using (FileStream stream = new(path, FileMode.Create))
            {
                await data.UploadImage.CopyToAsync(stream);
            }

            data.Image = fileName;


            await _context.Instructors.AddAsync(_mapper.Map<Instructor>(data));

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existSlider = await _context.Instructors.FindAsync(id);
            string path = Path.Combine(_env.WebRootPath, "img", existSlider.Image);

            if (File.Exists(path))
                File.Delete(path);

            _context.Instructors.Remove(existSlider);
            await _context.SaveChangesAsync();
        }

        //public Task DeleteInstructorSocialAsync(InstructorSocialDeleteDTo data)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task EditAsync(int id, InstructorEditDto data)
        {
            var existSlider = await _context.Instructors.FindAsync(id);
            if (data.UploadImage is not null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "img", existSlider.Image);
                if (File.Exists(oldPath))
                    File.Delete(oldPath);

                string fileName = Guid.NewGuid().ToString() + "-" + data.UploadImage.FileName;
                string newPath = Path.Combine(_env.WebRootPath, "img", fileName);

                using (FileStream stream = new(newPath, FileMode.Create))
                {
                    await data.UploadImage.CopyToAsync(stream);
                }


                data.Image = fileName;
            }


            _mapper.Map(data, existSlider);

            await _context.SaveChangesAsync();

        }

        //public Task<bool> ExistEmailAsync(string email)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> ExistPhoneAsync(string phone)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<InstructorDTo>> GetAllAsync()
        {
            return _mapper.Map<List<InstructorDTo>>(await _context.Instructors.AsTracking().ToListAsync());

        }


        //public Task<IEnumerable<Instructor>> GetAllWithSocialsAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<InstructorDTo> GetByIdAsync(int id)
        {
            return _mapper.Map<InstructorDTo>(await _context.Instructors.AsTracking().FirstOrDefaultAsync(m => m.Id == id));

        }

        //public Task<int> GetCountAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
