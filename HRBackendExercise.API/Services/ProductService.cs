using HRBackendExercise.API.Abstractions;
using HRBackendExercise.API.Models;

namespace HRBackendExercise.API.Services
{
	public class ProductService : IProductsService
	{
		// DO NOT MODIFY THE SIGNATURES, JUST THE BODIES
		public List<Product> Products { get; set; } = new List<Product>();
		public Product Create(Product entity)
		{
			if(Products.Any())
			{
				var maxId = Products.Max(x => x.Id);
				entity.Id = maxId + 1;
			}else
			{
				entity.Id = 1;
			}
			this.Products.Add(entity);

		 	return entity;
		}

		public Product? GetById(int id)
		{
			return Products.SingleOrDefault(x => x.Id == id);
		}

		public IEnumerable<Product> GetAll()
		{
			return Products;
 		}

		public void Update(Product entity)
		{
 
			var product  = GetById(entity.Id);

			if(product == null){
				throw new Exception("Invalid entity.");
			}


			


			var indexOldProduct = Products.IndexOf(product);

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
