using BusinessLogicLayer.DTOs;


namespace BusinessLogicLayer.Services
{
	public interface IProductService
	{
		Task<ProductDTO> AddProductAsync(ProductDTO productDTO);
		Task<ProductDTO> GetProductByIdAsync(int productId);
		Task<ProductDTO> UpdateProductAsync(ProductDTO productDTO);
		Task DeleteProductAsync(int productId);
		Task<List<ProductDTO>> GetAllProductsAsync();
		Task<List<ProductDTO>> GetProductsByCategoryAsync(int categoryId);
	}
}
