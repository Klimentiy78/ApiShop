using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mappings
{
	public class AutoMapperOrdersProfile : Profile
	{
		public AutoMapperOrdersProfile()
		{
			CreateMap<Order, OrderDTO>().ReverseMap();
		}
	}
}
