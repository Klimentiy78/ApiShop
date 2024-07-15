using AutoMapper;
using DataAccessLayer.Repositories;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;

public class ProductService : IProductService
{
	private readonly IProductRepository _productRepository;
	private readonly IMapper _mapper;

	public ProductService(IProductRepository productRepository, IMapper mapper)
	{
		_productRepository = productRepository;
		_mapper = mapper;
	}

	public async Task<ProductDTO> AddProductAsync(ProductDTO productDto)
	{
		var product = _mapper.Map<Product>(productDto);
		await _productRepository.AddProductAsync(product);
		return _mapper.Map<ProductDTO>(product);
	}

	public async Task<ProductDTO> GetProductByIdAsync(int productId)
	{
		var product = await _productRepository.GetProductByIdAsync(productId);
		return _mapper.Map<ProductDTO>(product);
	}

	public async Task<ProductDTO> UpdateProductAsync(ProductDTO productDto)
	{
		var product = _mapper.Map<Product>(productDto);
		await _productRepository.UpdateProductAsync(product);
		return _mapper.Map<ProductDTO>(product);
	}

	public async Task DeleteProductAsync(int productId)
	{
		await _productRepository.DeleteProductAsync(productId);
	}

	public async Task<List<ProductDTO>> GetAllProductsAsync()
	{
		var products = await _productRepository.GetAllProductsAsync();
		return _mapper.Map<List<ProductDTO>>(products);
	}

	public async Task<List<ProductDTO>> GetProductsByCategoryAsync(int categoryId)
	{
		var products = await _productRepository.GetProductsByCategoryAsync(categoryId);
		return _mapper.Map<List<ProductDTO>>(products);
	}
}
