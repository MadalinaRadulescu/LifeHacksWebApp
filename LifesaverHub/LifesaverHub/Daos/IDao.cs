namespace LifesaverHub.Daos;
public interface IDao<T>
{
    /// <summary>Add a new element to table.</summary>
    /// <param name="element">The element that u need to add.</param>
    Task Add(T element);
    
    /// <summary>Remove an element from the table.</summary>
    /// <param name="id">Id of the element that need to be removed.</param>
    Task Remove(string id);
    
    /// <summary>Update an element from the table.</summary>
    /// <param name="element">Replacing element with the same id as the old one.</param>
    Task Update(T element);
    
    /// <summary>Get an element from the table based on its id.</summary>
    /// <param name="id">Id of the element.</param>
    /// <returns>Element from the table that match the given id</returns>
    T Get(string id);
    
    /// <summary> Get all elements from the table. </summary>
    /// <returns> A list of all elements from the table. </returns>
    List<T> GetAll();
}