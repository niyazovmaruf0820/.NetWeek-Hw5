using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class OrderController
{
    private readonly OrderService orderService;
    public OrderController()
    {
        orderService = new OrderService();
    }
    [HttpPost("add-order")]
    public async Task<string> AddOrderAsync(Orders order)
    {
        return await orderService.AddValues(order);
    }
    [HttpGet("get-order")]
    public async Task<List<Orders>> GetOrdersAsync()
    {
        return await orderService.GetValues();
    }
    [HttpPut("update-order")]
    public async Task<string> UpdateCustomerAsync(Orders order)
    {
        return await orderService.UpdateValues(order);
    }
    [HttpDelete("delete-order")]
    public async Task<string> DeleteCustmerAsync(int id)
    {
        return await orderService.DeleteValues(id);
    }
    [HttpGet("GetCustomersByOrderDateInDiapazonAsync")]
    public async Task<List<Customers>> GetCustomersByOrderDateInDiapazonAsync(DateTime dateTime1,DateTime dateTime2)
    {
        return await orderService.GetCustomersByOrderDateInDiapazonAsync(dateTime1,dateTime2);
    }
    [HttpGet("GetCustomersByAvgOfOrderAmountsAsync")]
    public async Task<List<Customers>> GetCustomersByAvgOfOrderAmountsAsync()
    {
        return await orderService.GetCustomersByAvgOfOrderAmountsAsync();
    }
    [HttpGet("GetOrdersByAmountAsync")]
    public async Task<List<Orders>> GetOrdersByAmountAsync(decimal amount)
    {
        return await orderService.GetOrdersByAmountAsync(amount);
    }
}