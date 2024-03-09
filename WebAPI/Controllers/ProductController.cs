using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Models;
namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController
{
    // customer
    private readonly ProductService productService;
    public ProductController()
    {
        productService = new ProductService();
    }
    [HttpPost("add-product")]
    public async Task<string> AddProductAsync(Products product)
    {
        return await productService.AddValues(product);
    }
    [HttpGet("get-Products")]
    public async Task<List<Products>> GetProductsAsync()
    {
        return await productService.GetValues();
    }
    [HttpPut("update-product")]
    public async Task<string> UpdateProductAsync(Products product)
    {
        return await productService.UpdateValues(product);
    }
    [HttpDelete("delete-product")]
    public async Task<string> DeleteProductAsync(int id)
    {
        return await productService.DeleteValues(id);
    }
}
