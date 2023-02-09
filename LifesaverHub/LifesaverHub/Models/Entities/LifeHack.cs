using System.ComponentModel.DataAnnotations.Schema;

namespace LifesaverHub.Models.Entities;

public class LifeHack : DetaliedBaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string PhotoName { get; set; } = "";
    public string Link { get; set; } = "";
    public List<long> categoriesId { get; set; } = new();
}