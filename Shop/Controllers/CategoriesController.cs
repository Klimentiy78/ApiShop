using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.DTOs;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
	private readonly ICategoryService _categoryService;

	public CategoriesController(ICategoryService categoryService)
	{
		_categoryService = categoryService;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories()
	{
		var categories = await _categoryService.GetAllCategoriesAsync();
		return Ok(categories);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
	{
		var category = await _categoryService.GetCategoryByIdAsync(id);
		if (category == null)
		{
			return NotFound();
		}
		return Ok(category);
	}

	[HttpPost]
	public async Task<ActionResult> AddCategory([FromBody] CategoryDTO categoryDto)
	{
		await _categoryService.AddCategoryAsync(categoryDto);
		return CreatedAtAction(nameof(GetCategoryById), new { id = categoryDto.CategoryId }, categoryDto);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult> UpdateCategory(int id, [FromBody] CategoryDTO categoryDto)
	{
		if (id != categoryDto.CategoryId)
		{
			return BadRequest();
		}

		await _categoryService.UpdateCategoryAsync(categoryDto);
		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteCategory(int id)
	{
		await _categoryService.DeleteCategoryAsync(id);
		return NoContent();
	}
}
