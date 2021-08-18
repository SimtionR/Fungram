using Server.Data.Entities;
using Server.Data.IServices;
using System.Collections.Generic;
using System.Linq;

namespace Server.Data.Services
{
    public class CommentService : ICommentService
    {
        private readonly FungramContext _ctx;

        public CommentService(FungramContext ctx)
        {
            _ctx = ctx;
        }

        public void AddComment(Comment comment)
        {
            _ctx.Add(comment);
            _ctx.SaveChanges();
        }

        public IEnumerable<Comment> GetAllComents()
        {
            return _ctx.Comments
                        .OrderBy(c => c.PostId)
                        .ToList();
        }

        public Comment GetCommentById(int commentId)
        {
            return _ctx.Comments
                        .Where(c => c.CommentId == commentId)
                        .FirstOrDefault();
        }

        public IEnumerable<Comment> GetCommentsByProfile(int profileId)
        {
            return _ctx.Comments
                        .Where(c => c.ProfileId == profileId)
                        .ToList();
        }

        public IEnumerable<Comment> GetCommentsByPost(int postId)
        {
            return _ctx.Comments
                       .Where(c => c.PostId == postId)
                       .ToList();
        }

        public bool SaveChanges()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
