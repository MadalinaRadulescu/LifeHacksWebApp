using System.ComponentModel.DataAnnotations.Schema;

namespace LifesaverHub.Models.Entities;

public class Category
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Name { get; set; }
}