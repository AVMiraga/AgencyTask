using AgencyTask.Core.Entities.Common;
using AgencyTask.DAL.Context;
using AgencyTask.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgencyTask.DAL.Repositories.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseAuditableEntity, new()
    {
        private readonly AppDbContext _context;
        public DbSet<T> Table => _context.Set<T>();

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            DateTime time = DateTime.Now;

            entity.CreatedAt = time;
            entity.UpdatedAt = time;

            await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.Now;

            Table.Update(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(params string[] includes)
        {
            IQueryable<T> query = Table.Where(e => !e.IsDeleted);

            if(includes is not null)
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, params string[] includes)
        {
            IQueryable<T> query = Table.Where(e => !e.IsDeleted);

            if (includes is not null)
                foreach (var item in includes)
                {
                    query.Include(item);
                }

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<int> SaveChangesAsync()
        {
            int res = await _context.SaveChangesAsync();

            return res;
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }
    }
}
