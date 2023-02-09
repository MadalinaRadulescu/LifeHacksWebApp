using System.ComponentModel.DataAnnotations.Schema;

namespace LifesaverHub.Models.Entities;

public abstract class BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public long UserId { get; set; }
    
    public DateTime PublishedAt { get; set;  }  
    
    public long Points { get; set; } = 0;
}