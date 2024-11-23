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
				var maxId = Products.Max(x => x.Id);
				entity.Id = maxId++;
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
			return Products;
 		}

		public void Update(Product entity)
		{
			var oldPoduct = GetById(entity.Id);
			var indexOldProduct = Products.IndexOf(oldPoduct);

			Products[indexOldProduct].Description = entity.Description;
			Products[indexOldProduct].SKU = entity.SKU;
			Products[indexOldProduct].Price = entity.Price;

		}

		public void Delete(Product entity)
		{
		  Products.Remove(entity);
		}
	}
}
