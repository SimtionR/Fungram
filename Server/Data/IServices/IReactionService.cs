using Server.Data.Entities;
using System.Collections.Generic;

namespace Server.Data.IServices
{
    public interface IReactionService
    {
        IEnumerable<Reaction> GetAllReactionsByPost(int postId);
        void AddReaction(Reaction reaction);
        bool SaveChanges();
    }
}
