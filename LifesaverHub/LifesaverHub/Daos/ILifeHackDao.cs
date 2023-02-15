using LifesaverHub.Models.Entities;

namespace LifesaverHub.Daos;

public interface ILifeHackDao : ISpecificDao<LifeHack>
{
    /// <summary>Get all LifeHacks from the table based on the category.</summary>
    /// <param name="categoryId">Id of the category.</param>
    /// <returns>List of LifeHacks based on the desired category.</returns>
    List<LifeHack> GetByCategory(int categoryId);
    
    /// <summary>Update points number by +1.</summary>
    /// <param name="id">Id of the element from the table.</param>
    Task IncreasePoints(int id);
    
    /// <summary>Update points number by -1.</summary>
    /// <param name="id">Id of the element from the table.</param>
    Task DecreasePoints(int id);
}