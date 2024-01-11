using AgencyTask.Business.ViewModels.UserVms;
using AgencyTask.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace AgencyTask.Business.Services.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterResult> RegisterAsync(RegisterVm registerVm);
        Task<AppUser> ValidateUserCredentialsAsync(LoginVm loginVm);
        Task CreateRoleAsync();
    }

    public class RegisterResult
    {
        public IdentityResult? Result { get; set; }
        public AppUser? User { get; set; }
    }
}
