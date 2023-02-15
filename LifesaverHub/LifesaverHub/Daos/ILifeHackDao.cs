using LifesaverHub.Models.Entities;

namespace LifesaverHub.Daos;

public interface ILifeHackDao : IDetailedDao<LifeHack>, IDao<LifeHack>
{
    /// <summary>Get all LifeHacks from the table based on the category.</summary>
    /// <param name="categoryId">Id of the category.</param>
    /// <returns>List of LifeHacks based on the desired category.</returns>
    List<LifeHack> GetByCategory(int categoryId);
}