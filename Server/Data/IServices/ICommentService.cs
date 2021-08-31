using Server.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Data.IServices
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetCommentsByProfile(int profileId);
        public Task<IEnumerable<Comment>> GetCommentsByPost(int postId);
        Comment GetCommentById(int commentId);
        public Task<int> CreateComment(int profileId, int postId, string commentBody);
        public Task<bool> Delete(int commentId, int profileId);
        bool SaveChanges();
    }
}
