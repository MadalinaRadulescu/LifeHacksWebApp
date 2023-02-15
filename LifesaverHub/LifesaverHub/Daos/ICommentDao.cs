using LifesaverHub.Models.Entities;

namespace LifesaverHub.Daos;

public interface ICommentDao : ISpecificDao<Comment>
{
    
    /// <summary>Update points number by +1.</summary>
    /// <param name="id">Id of the element from the table.</param>
    Task IncreasePoints(int id);
    
    /// <summary>Update points number by -1.</summary>
    /// <param name="id">Id of the element from the table.</param>
    Task DecreasePoints(int id);
}