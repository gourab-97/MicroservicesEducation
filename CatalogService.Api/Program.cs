using CatalogService.Application.Products.Handlers;
using CatalogService.Domain.Interfaces;
using CatalogService.Infrastructure.Data;
using CatalogService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// DbContext (Infrastructure)
builder.Services.AddDbContext<CatalogDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CatalogDb")));

// Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Application Handlers
builder.Services.AddScoped<CreateProductHandler>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware

app.UseSwagger();
app.UseSwaggerUI();


app.MapControllers();
app.Run();
