using Dapper;
using Domain.Models;
using Infrastructure.Dapper;
using Infrastructure.Interface;

namespace Infrastructure.Services;

public class CustomerService : Interface<Customers>
{
    private DapperContext dapperContext = new DapperContext();

    public async Task<string> AddValues(Customers value)
    {
        await dapperContext.Connection().ExecuteAsync("insert into Customers(Customer_name,Email,Address)values(@customer_name,@email,@address)",value);
        return $"Added successfully";
    }

    public async Task<string> DeleteValues(int id)
    {
        await dapperContext.Connection().ExecuteAsync("delete from Customers where Id = @id",new {Id = id});
        return $"Deleted successfully";
    }

    public async Task<List<Customers>> GetValues()
    {
        var result = await dapperContext.Connection().QueryAsync<Customers>("select * from Customers");
        return result.ToList(); 
    }

    public async Task<string> UpdateValues(Customers value)
    {
        await dapperContext.Connection().ExecuteAsync("update Customers set Customer_name = @customer_name, Email = @email, Address = @address where Id = @id",value);
        return $"Updated sucsessfully";
    }
}
