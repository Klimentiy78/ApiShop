using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	public interface IProductRepository
	{
		Task<IEnumerable<Product>> GetAllProductsAsync();
		Task<Product> GetProductByIdAsync(int productId);
		Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
		Task AddProductAsync(Product product);
		Task UpdateProductAsync(Product product);
		Task DeleteProductAsync(int productId);
	}
}
