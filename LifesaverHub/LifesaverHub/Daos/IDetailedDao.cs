namespace LifesaverHub.Daos;

public interface IDetailedDao<T>
{
    /// <summary>
    /// Returns a list of elements of the specified type associated with the specified user ID.
    /// </summary>
    /// <param name="userId">The ID of the user associated with the elements to retrieve.</param>
    /// <returns>A list of elements of the specified type associated with the specified user ID.</returns>
    List<T> GetByUserId(string userId);
    
    /// <summary>
    /// Increases the points of an element with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the element whose points are to be increased.</param>
    /// <returns>A task that represents the asynchronous operation of updating the points of the element and saving changes to the database.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the ID is null or empty.</exception>
    Task IncreasePoints(string id);
    
    /// <summary>
    /// Decreases the points of an element in the table with the specified ID by one.
    /// </summary>
    /// <param name="id">The ID of the element to be updated.</param>
    /// <returns>A task that represents the asynchronous operation of decreasing the points and saving changes to the database.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the ID is null or empty.</exception>
    Task DecreasePoints(string id);
}