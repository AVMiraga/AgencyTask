using FluentValidation;

namespace AgencyTask.Business.ViewModels.CategoryVms
{
    public class UpdateCategoryVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCategoryVmValidation : AbstractValidator<UpdateCategoryVm>
    {
        public UpdateCategoryVmValidation()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}
