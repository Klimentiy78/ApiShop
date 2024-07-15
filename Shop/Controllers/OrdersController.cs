using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.DTOs;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
	private readonly IOrderService _orderService;

	public OrdersController(IOrderService orderService)
	{
		_orderService = orderService;
	}

	[HttpPost]
	public async Task<IActionResult> AddOrder(OrderDTO orderDTO)
	{
		var result = await _orderService.AddOrder(orderDTO);
		return CreatedAtAction(nameof(GetOrderById), new { id = result.UserId }, result);
	}

	[HttpGet]
	public async Task<IActionResult> GetAllOrders()
	{
		var result = await _orderService.GetAllOrders();
		return Ok(result);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetOrderById(int id)
	{
		var result = await _orderService.GetOrderById(id);
		if (result == null)
			return NotFound();
		return Ok(result);
	}

	[HttpGet("user/{userId}")]
	public async Task<IActionResult> GetOrdersByUserId(int userId)
	{
		var result = await _orderService.GetAllUserOrders(userId);
		return Ok(result);
	}
}
