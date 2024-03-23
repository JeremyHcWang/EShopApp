using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAPI.ApplicationCore.Entities;

public class Customer
{
    public int CustomerId { get; set; }
    [Column(TypeName="varchar(30)")]
    [Required (ErrorMessage ="Customer name is required")]
    public string Name { get; set; }
    [Column(TypeName="varchar(60)")]
    public string? Address { get; set; }
    [Column(TypeName="varchar(15)")]
    public string? City { get; set; }
    [Column(TypeName="varchar(25)")]
    [Required (ErrorMessage ="Customer phone is required")]
    public string Phone { get; set; }
}