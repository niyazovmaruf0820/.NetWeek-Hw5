using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class CustomerController
{
    private readonly CustomerService customerService;
    public CustomerController()
    {
        customerService = new CustomerService();
    }
    [HttpPost("add-customer")]
    public async Task<string> AddCustomerAsync(Customers customer)
    {
        return await customerService.AddValues(customer);
    }
    [HttpGet("get-customers")]
    public async Task<List<Customers>> GetCustomersAsync()
    {
        return await customerService.GetValues();
    }
    [HttpPut("update-customer")]
    public async Task<string> UpdateCustomerAsync(Customers customer)
    {
        return await customerService.UpdateValues(customer);
    }
    [HttpDelete("delete-customer")]
    public async Task<string> DeleteCustmerAsync(int id)
    {
        return await customerService.DeleteValues(id);
    }
}
