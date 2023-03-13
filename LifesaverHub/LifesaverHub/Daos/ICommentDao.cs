using LifesaverHub.Models.Entities;

namespace LifesaverHub.Daos;

public interface ICommentDao : IDetailedDao<Comment>, IDao<Comment>
{
    /// <summary>
    /// Gets a list of comments associated with a specified life hack.
    /// </summary>
    /// <param name="lifeHackId">The ID of the life hack to retrieve comments for.</param>
    /// <returns>A list of comments associated with the specified life hack.</returns>
    List<Comment> GetByLifeHackId(string lifeHackId);
}