using Dapper;
using Domain.Models;
using Infrastructure.Dapper;
using Infrastructure.Interface;
namespace Infrastructure.Services;

public class OrderDetailService : Interface<OrderDetails>
{
    private DapperContext dapperContext = new DapperContext();

    public async Task<string> AddValues(OrderDetails value)
    {
        await dapperContext.Connection().ExecuteAsync("insert into OrderDetails(Order_id,Product_id,Quantity,Unit_price)values(@order_id,@product_id,@quantity,@unit_price)",value);
        return $"Added successfully";
    }

    public async Task<string> DeleteValues(int id)
    {
        await dapperContext.Connection().ExecuteAsync("delete from OrderDetails where Id = @id",new {Id = id});
        return $"Deleted successfully";
    }

    public async Task<List<OrderDetails>> GetValues()
    {
        var result = await dapperContext.Connection().QueryAsync<OrderDetails>("select * from OrderDetails");
        return result.ToList(); 
    }

    public async Task<string> UpdateValues(OrderDetails value)
    {
        await dapperContext.Connection().ExecuteAsync("update OrderDetails set Order_id = @order_id, Product_id = @product_id, Quantity = @quantity,Unit_price = @unit_price  where Id = @id",value);
        return $"Updated sucsessfully";
    }
    public async Task<List<int>> GetQuantityAsync()
    {
        var sql = @"select Sum(od.Quantity) from OrderDetails as od";
        var result = await dapperContext.Connection().QueryAsync<int>(sql);
        return result.ToList();
    }
}
