using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services;

public class CategoryService : ICategoryService
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IMapper _mapper;

	public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
	{
		_categoryRepository = categoryRepository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
	{
		var categories = await _categoryRepository.GetAllCategoriesAsync();
		return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
	}

	public async Task<CategoryDTO> GetCategoryByIdAsync(int categoryId)
	{
		var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);
		return _mapper.Map<CategoryDTO>(category);
	}

	public async Task AddCategoryAsync(CategoryDTO categoryDto)
	{
		var category = _mapper.Map<Category>(categoryDto);
		await _categoryRepository.AddCategoryAsync(category);
	}

	public async Task UpdateCategoryAsync(CategoryDTO categoryDto)
	{
		var category = _mapper.Map<Category>(categoryDto);
		await _categoryRepository.UpdateCategoryAsync(category);
	}

	public async Task DeleteCategoryAsync(int categoryId)
	{
		await _categoryRepository.DeleteCategoryAsync(categoryId);
	}
}
