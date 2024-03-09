using Domain.Models;
using Dapper;
namespace Infrastructure.Services;
using Infrastructure.Interface;
using Infrastructure.Dapper;

public class ProductService : Interface<Products>
{
    private DapperContext dapperContext = new DapperContext();

    public async Task<string> AddValues(Products value)
    {
        await dapperContext.Connection().ExecuteAsync("insert into Products(Product_name,Price,Stock_quantity)values(@product_name,@price,@stock_quantity)",value);
        return $"Added successfully";
    }

    public async Task<string> DeleteValues(int id)
    {
        await dapperContext.Connection().ExecuteAsync("delete from Products where Id = @id",new {Id = id});
         return $"Deleted successfully";
    }

    public async Task<List<Products>> GetValues()
    {
        var result = await dapperContext.Connection().QueryAsync<Products>("select * from Products");
        return result.ToList(); 
    }

    public async Task<string> UpdateValues(Products value)
    {
        await dapperContext.Connection().ExecuteAsync("update Products set Product_name = @product_name, Price = @price, Stock_quantity = @stock_quantity where Product_id = @product_id",value);
        return $"Updated successfully";
    }
}
