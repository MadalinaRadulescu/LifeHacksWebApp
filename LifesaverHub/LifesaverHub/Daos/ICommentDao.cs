using LifesaverHub.Models.Entities;

namespace LifesaverHub.Daos;

public interface ICommentDao : IDetailedDao<Comment>, IDao<Comment>
{
}