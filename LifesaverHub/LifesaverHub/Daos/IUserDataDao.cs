using LifesaverHub.Models.Entities;

namespace LifesaverHub.Daos;

public interface IUserDataDao : ISpecificDao<UserData>
{
    
    /// <summary>Update points number by +1.</summary>
    /// <param name="id">Id of the element from the table.</param>
    Task IncreasePoints(string id);
    
    /// <summary>Update points number by -1.</summary>
    /// <param name="id">Id of the element from the table.</param>
    Task DecreasePoints(string id);
}