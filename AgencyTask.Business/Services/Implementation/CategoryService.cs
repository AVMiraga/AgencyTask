using AgencyTask.Business.Services.Interfaces;
using AgencyTask.Business.ViewModels.CategoryVms;
using AgencyTask.Core.Entities;
using AgencyTask.DAL.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace AgencyTask.Business.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repo;
        private readonly IWebHostEnvironment _env;

        public CategoryService(IMapper mapper, ICategoryRepository repo, IWebHostEnvironment env)
        {
            _mapper = mapper;
            _repo = repo;
            _env = env;
        }

        public async Task CreateAsync(CreateCategoryVm vm)
        {
            Category category = _mapper.Map<Category>(vm);

            await _repo.CreateAsync(category);
            await _repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Category category = await _repo.GetByIdAsync(id);

            _repo.Delete(category);
            await _repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task UpdateAsync(UpdateCategoryVm vm)
        {
            Category category = _mapper.Map<Category>(vm);

            _repo.Update(category);
            await _repo.SaveChangesAsync();
        }
    }
}
