namespace Domain.Models;

public class OrderDetails
{
    public int Order_detail_id { get; set; }
    public int Order_id { get; set; }
    public int Product_id { get; set; }
    public int Quantity { get; set; }
    public decimal Unit_price { get; set; }
}
