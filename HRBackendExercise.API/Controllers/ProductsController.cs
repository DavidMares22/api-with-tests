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

        public IActionResult Get(int id)
		{
			var product = this.productsService.GetById(id);
			return Ok(product);
		}

		public IActionResult GetAll()
		{
			var products = this.productsService.GetAll();
			return Ok(products);
		}

		public IActionResult Post(Product product)
		{
			if(product == null)
			{
				return BadRequest();
			}

			var result = this.productsService.Create(product);
			return Ok(result);
		}

		public IActionResult Put(Product product)
		{
			this.productsService.Update(product);

			return Ok();
		}

		public IActionResult Delete(int id)
		{
			var product = this.productsService.GetById(id);
			this.productsService.Delete(product);

			return NoContent();
		}
	}
}
