using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LifesaverHub.Models.Entities;

public class UserData : BaseEntity
{
    
    
    [AllowNull]
    public string CardHolder { get; set; }
    [AllowNull]
    public string CardNumber { get; set; }
    [AllowNull]
    public int ExpiryMonth { get; set; }
    [AllowNull]
    public int ExpiryYear { get; set; }
    [AllowNull]
    public string Cvv { get; set; }

    [AllowNull] 
    public string AddressLine1 { get; set; } 

    [AllowNull] 
    public string AddressLine2 { get; set; } = "";
    [AllowNull]
    public string PhoneNumber { get; set; }
    [AllowNull]
    public string City { get; set; }
    [AllowNull]
    public string Country { get; set; }
    [AllowNull]
    public string ZipCode { get; set; }
    
    
}