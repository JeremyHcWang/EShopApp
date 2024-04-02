using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI_ApplicationCore.Entities;

public class Product
{
    public int ProductId { get; set; }
    [Column(TypeName="varchar(25)")]
    [Required (ErrorMessage ="Product name is required")]
    public string ProductName { get; set; }
    [Column(TypeName="money")]
    [Required (ErrorMessage ="Unit price is required")]
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }   
}