using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AgencyTask.Business.ViewModels.PortfolioVms
{
    public class CreatePortfolioVm
    {
        public string Title { get; set; }
        public string HtmlBody { get; set; }
        public IFormFile CoverImageFile { get; set; }
        public IFormFile MainImageFile { get; set; }
        public List<int> CategoryIds { get; set; }
    }

    public class CreatePortfolioVmValidatior : AbstractValidator<CreatePortfolioVm>
    {
        public CreatePortfolioVmValidatior()
        {
            RuleFor(x => x.Title)
              .NotNull()
              .NotEmpty();

            RuleFor(x => x.HtmlBody)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.CoverImageFile)
                .NotNull();

            RuleFor(x => x.MainImageFile)
                .NotNull();

            RuleFor(x => x.CategoryIds)
                .NotNull()
                .NotEmpty();
        }
    }
}
