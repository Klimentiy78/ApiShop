using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.DTOs;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
	private readonly IUserService _userService;

	public UsersController(IUserService userService)
	{
		_userService = userService;
	}

	[HttpPost]
	public async Task<IActionResult> AddUser(UserDTO userDTO)
	{
		var result = await _userService.AddUser(userDTO);
		return CreatedAtAction(nameof(GetUserById), new { id = result.UserId }, result);
	}

	[HttpGet]
	public async Task<IActionResult> GetAllUsers()
	{
		var result = await _userService.GetAllUsers();
		return Ok(result);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetUserById(int id)
	{
		var result = await _userService.GetUserById(id);
		if (result == null)
			return NotFound();
		return Ok(result);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateUser(int id, UserDTO userDTO)
	{
		if (id != userDTO.UserId)
			return BadRequest();

		var result = await _userService.UpdateUser(userDTO);
		return Ok(result);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteUser(int id)
	{
		await _userService.DeleteUser(id);
		return NoContent();
	}
}


