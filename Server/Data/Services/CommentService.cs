using Microsoft.EntityFrameworkCore;
using Server.Data.Entities;
using Server.Data.IServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data.Services
{
    public class CommentService : ICommentService
    {
        private readonly FungramContext _ctx;

        public CommentService(FungramContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<int> CreateComment(int profileId, int postId, string commentBody)
        {
            var post=await this._ctx.Posts
                .Where(p => p.PostId == postId)
                .FirstOrDefaultAsync();

            var commnet = new Comment
            {
                Post = post,
                ProfileId = profileId,
                CommentBody = commentBody
            };

            post.Comments.Add(commnet);

            await this._ctx.SaveChangesAsync();

            return commnet.CommentId;
        }

      /*  public IEnumerable<Comment> GetAllComents()
        {
            return _ctx.Comments
                        .OrderBy(c => c.PostId)
                        .ToList();
        }*/

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

        public async Task<IEnumerable<Comment>> GetCommentsByPost(int postId)
        {
            return await _ctx.Comments
                       .Include(c => c.Profile)
                       .Where(c => c.PostId == postId)
                       .ToListAsync();
        }

        public bool SaveChanges()
        {
            return _ctx.SaveChanges() > 0;
        }

        public async Task<bool> Delete(int commentId, int profileId)
        {
            var comment = await _ctx.Comments
                            .Where(c => c.CommentId == commentId && c.ProfileId == profileId)
                            .FirstOrDefaultAsync();

            if (comment != null)
            {
                _ctx.Comments.Remove(comment);
                _ctx.SaveChangesAsync();
                return true;
            }

            else
                return false;
        }
    }
}
