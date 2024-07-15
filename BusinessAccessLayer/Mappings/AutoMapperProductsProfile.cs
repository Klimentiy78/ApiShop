using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mappings
{
	public class AutoMapperProductsProfile : Profile
	{
		public AutoMapperProductsProfile()
		{
			CreateMap<Product, ProductDTO>().ReverseMap();
		}
	}
}