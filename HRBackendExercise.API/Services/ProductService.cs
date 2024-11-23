using HRBackendExercise.API.Abstractions;
using HRBackendExercise.API.Models;

namespace HRBackendExercise.API.Services
{
	public class ProductService : IProductsService
	{
		// DO NOT MODIFY THE SIGNATURES, JUST THE BODIES
		public List<Product> Products { get; set; }
		public Product Create(Product entity)
		{
			if(Products.Any())
			{
				var lastProduct = Products.Last();
				entity.Id = lastProduct.Id++;
			}else
			{
				entity.Id = 1;
			}


		 	return entity;
		}

		public Product? GetById(int id)
		{
			return Products.Single(x => x.Id == id);
		}

		public IEnumerable<Product> GetAll()
		{
			throw new NotImplementedException();
		}

		public void Update(Product entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(Product entity)
		{
			throw new NotImplementedException();
		}
	}
}
