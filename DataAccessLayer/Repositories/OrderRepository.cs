using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
	public class OrderRepository: IOrderRepository
	{
		private readonly ApplicationContext _context;

		public OrderRepository(ApplicationContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Order>> GetAllOrdersAsync()
		{
			return await _context.Orders
				.Include(o => o.OrderItems)
				.ThenInclude(oi => oi.Product)
				.ToListAsync();
		}

		public async Task<Order> GetOrderByIdAsync(int orderId)
		{
			return await _context.Orders
				.Include(o => o.OrderItems)
				.ThenInclude(oi => oi.Product)
				.FirstOrDefaultAsync(o => o.OrderId == orderId);
		}

		public async Task AddOrderAsync(Order order)
		{
			_context.Orders.Add(order);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateOrderAsync(Order order)
		{
			_context.Orders.Update(order);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteOrderAsync(int orderId)
		{
			var order = await _context.Orders.FindAsync(orderId);
			if (order != null)
			{
				_context.Orders.Remove(order);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
		{
			return await _context.Orders.Where(order => order.UserId == userId).ToListAsync();
		}
	}
}
