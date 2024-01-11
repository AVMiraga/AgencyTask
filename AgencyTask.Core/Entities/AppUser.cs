using Microsoft.AspNetCore.Identity;

namespace AgencyTask.Core.Entities
{
	public class AppUser : IdentityUser
	{ 
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
