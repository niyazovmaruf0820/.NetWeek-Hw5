using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class OrderDetailController
{
    private readonly OrderDetailService orderDetailService;
    public OrderDetailController()
    {
        orderDetailService = new OrderDetailService();
    }
    [HttpPost("add-orderdetail")]
    public async Task<string> AddOrderdetailAsync(OrderDetails orderDetail)
    {
        return await orderDetailService.AddValues(orderDetail);
    }
    [HttpGet("get-orderdetails")]
    public async Task<List<OrderDetails>> GetOrderdetailsAsync()
    {
        return await orderDetailService.GetValues();
    }
    [HttpPut("update-orderdetail")]
    public async Task<string> UpdateOrderdetailAsync(OrderDetails orderDetail)
    {
        return await orderDetailService.UpdateValues(orderDetail);
    }
    [HttpDelete("delete-orderdetail")]
    public async Task<string> DeleteOrderdetailAsync(int id)
    {
        return await orderDetailService.DeleteValues(id);
    }
    [HttpGet("GetQuantityAsync")]
    public async Task<List<int>> GetQuantityAsync()
    {
        return await orderDetailService.GetQuantityAsync();
    }
}
