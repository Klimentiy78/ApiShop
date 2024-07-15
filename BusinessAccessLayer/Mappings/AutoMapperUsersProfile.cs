using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mappings
{
	public class AutoMapperUsersProfile : Profile
	{
		public AutoMapperUsersProfile()
		{
			CreateMap<User, UserDTO>().ReverseMap();
		}
	}
}
