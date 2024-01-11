using AgencyTask.Business.Helpers;
using AgencyTask.Business.Services.Interfaces;
using AgencyTask.Business.ViewModels.PortfolioVms;
using AgencyTask.Core.Entities;
using AgencyTask.DAL.Repositories.Interfaces;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace AgencyTask.Business.Services.Implementation
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IMapper _mapper;
        private readonly IPortfolioRepository _repo;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _env;
        private readonly IValidator<CreatePortfolioVm> _createValidator;
        private readonly IValidator<UpdatePortfolioVm> _updateValidator;

        public PortfolioService(IMapper mapper, IPortfolioRepository repo, IWebHostEnvironment env, ICategoryRepository categoryRepository, IValidator<CreatePortfolioVm> createValidator, IValidator<UpdatePortfolioVm> updateValidator)
        {
            _mapper = mapper;
            _repo = repo;
            _env = env;
            _categoryRepository = categoryRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task CreateAsync(CreatePortfolioVm vm)
        {
            Portfolio portfolio = _mapper.Map<Portfolio>(vm);

            ValidationResult validationResult = await _createValidator.ValidateAsync(vm);

            if (!validationResult.IsValid)
            {
                throw new Exception("Something went wrong");
            }

            string CoverName = await vm.CoverImageFile.UploadFile(_env.WebRootPath, "Upload");
            string MainName = await vm.MainImageFile.UploadFile(_env.WebRootPath, "Upload");

            portfolio.CoverImage = CoverName;
            portfolio.MainImage = MainName;

            portfolio.Categories = new List<Category>();

            foreach (var item in vm.CategoryIds)
            {
                portfolio.Categories.Add(await _categoryRepository.GetByIdAsync(item));
            }

            await _repo.CreateAsync(portfolio);
            await _repo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Portfolio portfolio = await _repo.GetByIdAsync(id, "Category");

            _repo.Delete(portfolio);
            await _repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<Portfolio>> GetAllAsync()
        {
            return await _repo.GetAllAsync("Category");
        }

        public async Task<Portfolio> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id, "Category");
        }

        public async Task UpdateAsync(UpdatePortfolioVm vm)
        {
            Portfolio portfolio =  _mapper.Map<Portfolio>(vm);

            ValidationResult validationResult = await _updateValidator.ValidateAsync(vm);

            if(!validationResult.IsValid)
            {
                throw new Exception("Something went wrong");
            }

            if(vm.CoverImageFile != null) 
            {
                string CoverName = await vm.CoverImageFile.UploadFile(_env.WebRootPath, "Upload");

                portfolio.CoverImage = CoverName;
            }

            if(vm.MainImageFile != null) 
            {
                string MainName = await vm.MainImageFile.UploadFile(_env.WebRootPath, "Upload");

                portfolio.MainImage = MainName;
            }

            portfolio.Categories.Clear();

            foreach (var item in vm.CategoryIds)
            {
                portfolio.Categories.Add(await _categoryRepository.GetByIdAsync(item));
            }

            _repo.Update(portfolio);
            await _repo.SaveChangesAsync();
        }
    }
}
