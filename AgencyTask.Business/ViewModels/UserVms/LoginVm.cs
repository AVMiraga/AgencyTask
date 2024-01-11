using FluentValidation;

namespace AgencyTask.Business.ViewModels.UserVms
{
    public class LoginVm
    {
        public string LoginId { get; set; }
        public string Password { get; set; }
    }

    public class LoginVmValidation : AbstractValidator<LoginVm>
    {
        public LoginVmValidation()
        {
            RuleFor(x => x.LoginId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty();
        }
    }
}
