using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	public interface IOrderItemRepository
	{
		Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync();
		Task<OrderItem> GetOrderItemByIdAsync(int orderItemId);
		Task AddOrderItemAsync(OrderItem orderItem);
		Task UpdateOrderItemAsync(OrderItem orderItem);
		Task DeleteOrderItemAsync(int orderItemId);
	}
}
