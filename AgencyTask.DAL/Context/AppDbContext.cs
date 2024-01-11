using AgencyTask.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgencyTask.DAL.Context
{
	public class AppDbContext : IdentityDbContext<AppUser>
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Portfolio> Portfolios { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}
