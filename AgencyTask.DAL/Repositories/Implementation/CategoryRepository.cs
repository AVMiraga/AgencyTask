using AgencyTask.Core.Entities;
using AgencyTask.DAL.Context;
using AgencyTask.DAL.Repositories.Interfaces;

namespace AgencyTask.DAL.Repositories.Implementation
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
