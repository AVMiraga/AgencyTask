using FluentValidation;

namespace AgencyTask.Business.ViewModels.UserVms
{
    public class RegisterVm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterVmValidation : AbstractValidator<RegisterVm>
    {
        public RegisterVmValidation() 
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Username)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.ConfirmPassword)
                .NotNull()
                .NotEmpty()
                .Equal(p => p.Password);
        }
    }
}
