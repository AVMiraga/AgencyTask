using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace AgencyTask.Business.ViewModels.PortfolioVms
{
    public class UpdatePortfolioVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string HtmlBody { get; set; }
        public IFormFile? CoverImageFile { get; set; }
        public IFormFile? MainImageFile { get; set; }
        public List<int> CategoryIds { get; set; }
    }

    public class UpdatePortfolioVmValidatior : AbstractValidator<UpdatePortfolioVm>
    {
        public UpdatePortfolioVmValidatior()
        {
            RuleFor(x => x.Title)
              .NotNull()
              .NotEmpty();

            RuleFor(x => x.HtmlBody)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.CategoryIds)
                .NotNull()
                .NotEmpty();
        }
    }
}
