using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
	public class OrderItemRepository: IOrderItemRepository
	{
		private readonly ApplicationContext _context;

		public OrderItemRepository(ApplicationContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync()
		{
			return await _context.OrderItems.ToListAsync();
		}

		public async Task<OrderItem> GetOrderItemByIdAsync(int orderItemId)
		{
			return await _context.OrderItems.FindAsync(orderItemId);
		}

		public async Task AddOrderItemAsync(OrderItem orderItem)
		{
			_context.OrderItems.Add(orderItem);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateOrderItemAsync(OrderItem orderItem)
		{
			_context.OrderItems.Update(orderItem);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteOrderItemAsync(int orderItemId)
		{
			var orderItem = await _context.OrderItems.FindAsync(orderItemId);
			if (orderItem != null)
			{
				_context.OrderItems.Remove(orderItem);
				await _context.SaveChangesAsync();
			}
		}
	}
}
