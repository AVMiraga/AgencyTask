using AgencyTask.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace AgencyTask.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseAuditableEntity, new()
    {
        public DbSet<T> Table { get; }
        public Task<T> GetByIdAsync(int id, params string[] includes);
        public Task<IEnumerable<T>> GetAllAsync(params string[] includes);
        public Task CreateAsync (T entity);
        public void Update (T entity);
        public void Delete (T entity);

        public Task<int> SaveChangesAsync();
    }
}
