using AgencyTask.Business.ViewModels.CategoryVms;
using AgencyTask.Business.ViewModels.PortfolioVms;
using AgencyTask.Core.Entities;

namespace AgencyTask.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
        Task CreateAsync(CreateCategoryVm vm);
        Task UpdateAsync(UpdateCategoryVm vm);
        Task DeleteAsync(int id);
    }
}
