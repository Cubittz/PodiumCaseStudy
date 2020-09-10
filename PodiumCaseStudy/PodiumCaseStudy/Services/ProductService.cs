using PodiumCaseStudy.Data.Entities;
using PodiumCaseStudy.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PodiumCaseStudy.Services
{
    public class ProductService  : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _repository.GetAllAsync();
            return products;
        }
    }
}
