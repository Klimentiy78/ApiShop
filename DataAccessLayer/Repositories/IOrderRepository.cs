﻿using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	public interface IOrderRepository
	{
		Task<IEnumerable<Order>> GetAllOrdersAsync();
		Task<Order> GetOrderByIdAsync(int orderId);
		Task AddOrderAsync(Order order);
		Task UpdateOrderAsync(Order order);
		Task DeleteOrderAsync(int orderId);
		Task<List<Order>> GetOrdersByUserIdAsync(int userId);
	}
}