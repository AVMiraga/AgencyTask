using AgencyTask.Core.Entities;
using AgencyTask.DAL.Context;
using AgencyTask.DAL.Repositories.Interfaces;

namespace AgencyTask.DAL.Repositories.Implementation
{
    public class PortfolioRepository : Repository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(AppDbContext context) : base(context)
        {
        }
    }
}
