using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;

namespace BusinessAccessLayer.Mappings
{
	public class AutoMapperOrderItemsProfile : Profile
	{
		public AutoMapperOrderItemsProfile()
		{
			CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
		}
	}
}