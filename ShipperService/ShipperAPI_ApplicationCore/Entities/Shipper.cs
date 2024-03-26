using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShipperAPI_ApplicationCore.Entities;

public class Shipper
{
    public int ShipperId { get; set; }
    [Column(TypeName="varchar(25)")]
    [Required (ErrorMessage ="Department Name is required")]
    public string CompanyName { get; set; }
    public int Phone { get; set; }
}