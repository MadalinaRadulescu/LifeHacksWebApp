namespace LifesaverHub.Daos;

public interface IDetailedDao<T>
{
    /// <summary>Get an element from the table based on the user id.</summary>
    /// <param name="userId">Id of the user who own that data.</param>
    /// <returns>Element from the table that match the user id</returns>
    List<T> GetByUserId(string userId);
    
    /// <summary>Update points number by +1.</summary>
    /// <param name="id">Id of the element from the table.</param>
    Task IncreasePoints(string id);
    
    /// <summary>Update points number by -1.</summary>
    /// <param name="id">Id of the element from the table.</param>
    Task DecreasePoints(string id);
}