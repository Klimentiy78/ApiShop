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
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IMapper _mapper;

		public OrderService(IOrderRepository orderRepository, IMapper mapper)
		{
			_orderRepository = orderRepository;
			_mapper = mapper;
		}

		public async Task<OrderDTO> AddOrder(OrderDTO orderDTO)
		{
			var order = _mapper.Map<Order>(orderDTO);
			await _orderRepository.AddOrderAsync(order);
			return _mapper.Map<OrderDTO>(order);
		}

		public async Task<List<OrderDTO>> GetAllOrders()
		{
			var orders = await _orderRepository.GetAllOrdersAsync();
			return _mapper.Map<List<OrderDTO>>(orders);
		}

		public async Task<OrderDTO> GetOrderById(int orderId)
		{
			var order = await _orderRepository.GetOrderByIdAsync(orderId);
			return _mapper.Map<OrderDTO>(order);
		}

		public async Task<List<OrderDTO>> GetAllUserOrders(int userId)
		{
			var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
			return _mapper.Map<List<OrderDTO>>(orders);
		}


	}

}
