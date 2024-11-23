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

        public ProductsController(IProductsService productsService)
		{
				
        }

        public IActionResult Get(int id)
		{
			throw new NotImplementedException();
		}

		public IActionResult Post(Product product)
		{
			throw new NotImplementedException();
		}

		public IActionResult Put(Product product)
		{
			throw new NotImplementedException();
		}

		public IActionResult Delete(int id)
		{
			throw new NotImplementedException();
		}
	}
}
