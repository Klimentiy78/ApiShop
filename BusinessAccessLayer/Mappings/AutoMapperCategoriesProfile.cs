using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mappings
{
	public class AutoMapperCategoriesProfile : Profile
	{
		public AutoMapperCategoriesProfile()
		{
			CreateMap<Category, CategoryDTO>().ReverseMap();
		}
	}
}
