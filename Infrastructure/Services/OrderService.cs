using Dapper;
using Domain.Models;
using Infrastructure.Dapper;
using Infrastructure.Interface;
namespace Infrastructure.Services;

public class OrderService : Interface<Orders>
{
    private DapperContext dapperContext = new DapperContext();

    public async Task<string> AddValues(Orders value)
    {
        await dapperContext.Connection().ExecuteAsync("insert into Orders(Customer_id,Order_date,Total_amount)values(@customer_id,@order_date,@total_amount)", value);
        return $"Added successfully";
    }

    public async Task<string> DeleteValues(int id)
    {
        await dapperContext.Connection().ExecuteAsync("delete from Orders where Id = @id", new { Id = id });
        return $"Deleted successfully";
    }

    public async Task<List<Orders>> GetValues()
    {
        var result = await dapperContext.Connection().QueryAsync<Orders>("select * from Orders");
        return result.ToList();
    }

    public async Task<string> UpdateValues(Orders value)
    {
        await dapperContext.Connection().ExecuteAsync("update Orders set Customer_id = @customer_id, Order_date = @order_date, Total_amount = @total_amount where Id = @id", value);
        return $"Updated sucsessfully";
    }
    public async Task<List<Customers>> GetCustomersByOrderDateInDiapazonAsync(DateTime dateTime1,DateTime dateTime2)
    {
        var sql = @"select c.Customer_id,c.Customer_name,c.Email,c.Address from Customers as c
                    join Orders as o on o.Customer_id = c.Customer_id
                    where o.Order_date >= @dateTime1 and o.Order_date <= @dateTime2";
        var result = await dapperContext.Connection().QueryAsync<Customers>(sql,new {DateTime1 = dateTime1,DateTime2 = dateTime2});
        return result.ToList();
    }
    public async Task<List<Customers>> GetCustomersByAvgOfOrderAmountsAsync()
    {
        var sql = @"select c.Customer_id,c.Customer_name,c.Email,c.Address,Avg(o.Total_amount) as Avg from Customers as c
                    join Orders as o on o.Customer_id = c.Customer_id
                    group by c.Customer_id";
        var result = await dapperContext.Connection().QueryAsync<Customers>(sql);
        return result.ToList();
    }
    public async Task<List<Orders>> GetOrdersByAmountAsync(decimal value)
    {
        var sql = @"select * from Orders 
                    where Total_amount > @value";
        var result = await dapperContext.Connection().QueryAsync<Orders>(sql,new {Value = value});
        return result.ToList();
    }
}
