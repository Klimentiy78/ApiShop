﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.DTOs;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
	private readonly IProductService _productService;

	public ProductsController(IProductService productService)
	{
		_productService = productService;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
	{
		var products = await _productService.GetAllProductsAsync();
		return Ok(products);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<ProductDTO>> GetProductById(int id)
	{
		var product = await _productService.GetProductByIdAsync(id);
		if (product == null)
		{
			return NotFound();
		}
		return Ok(product);
	}

	[HttpPost]
	public async Task<ActionResult> AddProduct([FromBody] ProductDTO productDto)
	{
		await _productService.AddProductAsync(productDto);
		return CreatedAtAction(nameof(GetProductById), new { id = productDto.ProductId }, productDto);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductDTO productDto)
	{
		if (id != productDto.ProductId)
		{
			return BadRequest();
		}

		await _productService.UpdateProductAsync(productDto);
		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> DeleteProduct(int id)
	{
		await _productService.DeleteProductAsync(id);
		return NoContent();
	}
}
