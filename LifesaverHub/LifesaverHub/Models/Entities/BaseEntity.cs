using System.ComponentModel.DataAnnotations.Schema;

namespace LifesaverHub.Models.Entities;

public abstract class BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime RegistredTime { get; set; }
}