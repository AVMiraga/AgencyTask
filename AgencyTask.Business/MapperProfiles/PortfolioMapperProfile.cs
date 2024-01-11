using AgencyTask.Business.ViewModels.CategoryVms;
using AgencyTask.Business.ViewModels.PortfolioVms;
using AgencyTask.Core.Entities;
using AutoMapper;

namespace AgencyTask.Business.MapperProfiles
{
	public class PortfolioMapperProfile : Profile
	{
		public PortfolioMapperProfile()
		{
			CreateMap<CreatePortfolioVm, Portfolio>();

			CreateMap<UpdatePortfolioVm, Portfolio>();
			CreateMap<UpdatePortfolioVm, Portfolio>().ReverseMap();
		}
	}
}
