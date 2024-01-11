using FluentValidation;

namespace AgencyTask.Business.ViewModels.CategoryVms
{
    public class CreateCategoryVm
    {
        public string Name { get; set; }
    }

    public class CreateCategoryVmValidation : AbstractValidator<CreateCategoryVm>
    {
        public CreateCategoryVmValidation() 
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}
