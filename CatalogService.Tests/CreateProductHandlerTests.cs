using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogService.Application.Products.Commands;
using CatalogService.Application.Products.Handlers;
using CatalogService.Domain.Interfaces;
using Moq;
using Xunit;

namespace CatalogService.Tests.Tests
{
    public class CreateProductHandlerTests
    {
        [Fact]
        public async Task Should_Create_Product()
        {
            var repoMock = new Mock<IProductRepository>();
            var handler = new CreateProductHandler(repoMock.Object);

            var command = new CreateProductCommand("Pen", 10);

            var result = await handler.Handle(command);

            Assert.NotEqual(Guid.Empty, result);
            repoMock.Verify(r => r.AddAsync(It.IsAny<CatalogService.Domain.Entities.Product>()), Times.Once);
        }
    }
}
