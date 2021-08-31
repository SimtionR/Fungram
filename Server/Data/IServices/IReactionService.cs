using Server.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Data.IServices
{
    public interface IReactionService
    {
        public Task<IEnumerable<Reaction>> GetAllReactionsByPost(int postId);

        public  Task<int> Create(string reactionImage, int profileId, int postId, Post post);

        public Task<bool> Delete(int postId);
    
    }
}
