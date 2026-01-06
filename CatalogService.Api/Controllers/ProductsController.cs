using CatalogService.Application.Products.Commands;
using CatalogService.Application.Products.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly CreateProductHandler _handler;

    public ProductsController(CreateProductHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var id = await _handler.Handle(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    // Temporary read endpoint to support REST correctness
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(id);
    }
}
