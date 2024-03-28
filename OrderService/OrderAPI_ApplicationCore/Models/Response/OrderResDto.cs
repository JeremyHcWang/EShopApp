namespace OrderAPI_ApplicationCore.Models.Response;

public class OrderResDto
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public int ShipperId { get; set; }
    public DateTime OrderDate { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
}