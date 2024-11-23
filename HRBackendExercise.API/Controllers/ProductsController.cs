using HRBackendExercise.API.Abstractions;
using HRBackendExercise.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRBackendExercise.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		// DO NOT MODIFY THE SIGNATURES, JUST THE BODIES
		IProductsService productsService;
		public ProductsController(IProductsService productsService)
		{
			this.productsService = productsService;
		}
		[HttpGet]
		public IActionResult Get(int id)
		{
			try
			{
				var product = this.productsService.GetById(id);

				if (product == null)
				{
					return NotFound();
				}

				return Ok(product);
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "There was a problem retrieving the product." });
			}
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var products = this.productsService.GetAll();
			return Ok(products);
		}
		[HttpPost]
		public IActionResult Post(Product product)
		{
			if (product == null || product.SKU == null || product.Price <= 0)
			{
				return BadRequest();
			}

			try
			{

				var result = this.productsService.Create(product);
				return new ObjectResult(result) { StatusCode = 201 };
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "There was a problem retrieving the product." });
			}

		}
		[HttpPut]
		public IActionResult Put(Product product)
		{

			if (product == null || product.SKU == null || product.Price <= 0 || product.Id <= 0)
			{
				return BadRequest();
			}

			try
			{

				var oldPoduct = this.productsService.GetById(product.Id);

				if (oldPoduct == null)
				{
					return NotFound();
				}

				this.productsService.Update(product);

				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "There was a problem retrieving the product." });
			}

		}
		[HttpDelete]
		public IActionResult Delete(int id)
		{
			
			try
			{	 
			var product = this.productsService.GetById(id);
			if (product == null)
			{
				return NotFound();
			}

			this.productsService.Delete(product);

				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "There was a problem retrieving the product." });
			}


		}
	}
}
