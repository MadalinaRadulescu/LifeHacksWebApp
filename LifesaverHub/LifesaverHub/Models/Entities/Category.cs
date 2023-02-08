using System.ComponentModel.DataAnnotations.Schema;

namespace LifesaverHub.Models.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
}