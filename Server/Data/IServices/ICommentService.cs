using Server.Data.Entities;
using System.Collections.Generic;

namespace Server.Data.IServices
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetAllComents();
        IEnumerable<Comment> GetCommentsByProfile(int profileId);
        IEnumerable<Comment> GetCommentsByPost(int postId);
        Comment GetCommentById(int commentId);
        void AddComment(Comment comment);
        bool SaveChanges();
    }
}
