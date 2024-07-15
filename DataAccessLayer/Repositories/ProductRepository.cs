using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationContext _context;

		public ProductRepository(ApplicationContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Product>> GetAllProductsAsync()
		{
			return await _context.Products.ToListAsync();
		}

		public async Task<Product> GetProductByIdAsync(int productId)
		{
			return await _context.Products.FindAsync(productId);
		}

		public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
		{
			return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
		}

		public async Task AddProductAsync(Product product)
		{
			_context.Products.Add(product);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateProductAsync(Product product)
		{
			_context.Products.Update(product);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteProductAsync(int productId)
		{
			var product = await _context.Products.FindAsync(productId);
			if (product != null)
			{
				_context.Products.Remove(product);
				await _context.SaveChangesAsync();
			}
		}
	}
}
