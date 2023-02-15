using LifesaverHub.Models.Entities;

namespace LifesaverHub.Daos;

public interface ILifeHackDao : IDetailedDao<LifeHack>, IDao<LifeHack>
{
    /// <summary>
    /// Retrieves a list of life hacks by the specified category ID.
    /// </summary>
    /// <param name="categoryId">The ID of the category to search.</param>
    /// <returns>A list of life hacks that belong to the specified category.</returns>
    List<LifeHack> GetByCategory(int categoryId);
}