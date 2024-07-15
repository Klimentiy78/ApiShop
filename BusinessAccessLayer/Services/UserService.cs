using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public UserService(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public async Task<UserDTO> AddUser(UserDTO userDTO)
		{
			var user = _mapper.Map<User>(userDTO);
			await _userRepository.AddUserAsync(user);
			return _mapper.Map<UserDTO>(user);
		}

		public async Task<List<UserDTO>> GetAllUsers()
		{
			var users = await _userRepository.GetAllUsersAsync();
			return _mapper.Map<List<UserDTO>>(users);
		}

		public async Task<UserDTO> GetUserById(int userId)
		{
			var user = await _userRepository.GetUserByIdAsync(userId);
			return _mapper.Map<UserDTO>(user);
		}

		public async Task<UserDTO> UpdateUser(UserDTO userDTO)
		{
			var user = _mapper.Map<User>(userDTO);
			await _userRepository.UpdateUserAsync(user);
			return _mapper.Map<UserDTO>(user);
		}

		public async Task DeleteUser(int userId)
		{
			await _userRepository.DeleteUserAsync(userId);
		}
	}

}
