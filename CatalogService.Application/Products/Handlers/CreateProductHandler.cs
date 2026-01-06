using CatalogService.Application.Products.Commands;
using CatalogService.Domain.Entities;
using CatalogService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Products.Handlers
{
    public class CreateProductHandler
    {
        private readonly IProductRepository _repository;

        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateProductCommand command)
        {
            var product = new Product(command.Name, command.Price);
            await _repository.AddAsync(product);
            return product.Id;
        }
    }
}
