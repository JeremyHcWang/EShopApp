using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderAPI_ApplicationCore.Entities;

public class Order
{   
    // Existing properties
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public int ShipperId { get; set; }
    public DateTime OrderDate { get; set; }
    [Column(TypeName="varchar(60)")]
    [Required (ErrorMessage ="Shipping address is required")]
    public string ShipAddress { get; set; }
    [Column(TypeName="varchar(15)")]
    [Required (ErrorMessage ="Shipping city is required")]
    public string ShipCity { get; set; }
    
    // Navigation properties are not used to avoid direct reference between microservices
    // Instead, use HttpClient for service communication
    // public virtual Customer Customer { get; set; }
    // public virtual Shipper Shipper { get; set; }
}