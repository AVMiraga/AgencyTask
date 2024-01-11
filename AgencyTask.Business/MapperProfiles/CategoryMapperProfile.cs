using AgencyTask.Business.ViewModels.CategoryVms;
using AgencyTask.Core.Entities;
using AutoMapper;

namespace AgencyTask.Business.MapperProfiles
{
	public class CategoryMapperProfile : Profile
	{
		public CategoryMapperProfile()
		{
			CreateMap<CreateCategoryVm, Category>();

			CreateMap<UpdateCategoryVm, Category>();
			CreateMap<UpdateCategoryVm, Category>().ReverseMap();
		}
	}
}
