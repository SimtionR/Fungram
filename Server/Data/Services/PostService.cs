using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Data.Entities;
using Server.Data.IServices;
using Server.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InTouch.Data.Services
{
    public class PostService : IPostService
    {
        private readonly FungramContext _ctx;

        public PostService(FungramContext ctx)
        {
            _ctx = ctx;
        }
        public void AddPost(Post post)
        {
            _ctx.Add(post);
            _ctx.SaveChanges();
        }

        public  async Task<int> CreatePost(string imageUrl, string Description, int profileId)
        {
            var Post = new Post
            {
                ImageUrl = imageUrl,
                PostDescription = Description,
                ProfileId = profileId
            };

            _ctx.Add(Post);
            await _ctx.SaveChangesAsync();

            return Post.PostId;
        }

        public  async Task<IEnumerable<FeedListModel>> GetProfileFeed(int profileId)
        {
            return await this._ctx
                .Posts
                .Where(p => p.ProfileId == profileId)
                .Select(p => new FeedListModel
                {
                    PostId = p.PostId,
                    ImageUrl = p.ImageUrl,
                    PostDescription = p.PostDescription,
                    NumberOfReactions=p.NumberOfReactions

                })
                .ToListAsync();
        }

        public async Task<Post> GetPostById(int postId)
        {
            return await _ctx.Posts
                        .Where(p => p.PostId == postId)
                        .FirstOrDefaultAsync();
        }

        public IEnumerable<Post> GetPostsByProfile(int profileId)
        {
            return _ctx.Posts
                         .Where(p => p.ProfileId == profileId)
                         .ToList();
        }

        public bool SaveChanges()
        {
            return _ctx.SaveChanges()>0;
        }

        public async Task<PostDetailModel> GetDetailedPost(int postId)
        {
            return await this._ctx.
                Posts
                .Include(p => p.Comments)
                .Include(p => p.Reactions)
                .Where(p => p.PostId == postId)
                .Select(
                p => new PostDetailModel
                {
                    PostId= p.PostId,
                    ImageUrl=p.ImageUrl,
                    PostDescription=p.PostDescription,
                    Profile=p.Profile,
                    NumberOfReactions=p.NumberOfReactions,
                    Comments=p.Comments,
                    Reactions=p.Reactions,
                    ProfileId=p.ProfileId
                    
                 
                }).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(int id, string description, int profileId)
        {
            var post = await this
                ._ctx
                .Posts
                .Where(p => p.PostId == id && p.ProfileId == profileId)
                .FirstOrDefaultAsync();

            if(post == null)
            {
                return false;
            }

            else
            {
                post.PostDescription = description;

                await this._ctx.SaveChangesAsync();

                return true;
            }

        }

        public async Task<bool> Delete(int postId, int profileId)
        {
            var post = await this._ctx.Posts
                .Where(p => p.PostId == postId && p.ProfileId == profileId)
                .FirstOrDefaultAsync();

            if (post == null)
            {
                return false;
            }

            else
            {
                this._ctx.Posts.Remove(post);
                await this._ctx.SaveChangesAsync();

                return true;
            }
        }
    }
}
