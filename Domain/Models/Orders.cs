namespace Domain.Models;

public class Orders
{
    public int Order_id { get; set; }
    public int Customer_id { get; set; }
    public DateTime Order_date { get; set; }
    public decimal Total_amount { get; set; }
}
