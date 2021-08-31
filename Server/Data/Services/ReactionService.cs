using Microsoft.EntityFrameworkCore;
using Server.Data.Entities;
using Server.Data.IServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data.Services
{
    public class ReactionService : IReactionService
    {
        private readonly FungramContext _ctx;

        public ReactionService(FungramContext ctx)
        {
            _ctx = ctx;
        }

     

        public async Task<int> Create(string reactionImage, int profileId, int postId, Post post)
        {
            var reactionSearch= await this._ctx.Reactions
                .Where(r => r.ProfileId == profileId && r.PostId == postId)
                .FirstOrDefaultAsync();

            if (reactionSearch == null)
            {

                var reaction = new Reaction
                {
                    PostId = postId,
                    ProfileId = profileId,
                    ReactionImage = reactionImage,
                    Post = post
                };
                _ctx.Reactions.Add(reaction);
                post.NumberOfReactions++;

                await _ctx.SaveChangesAsync();

                return reaction.ReactionId;
            }

            else return 0;


            

        }

        public async Task<bool> Delete(int postId)
        {
            var searchedReaction = await this._ctx.Reactions
                          .Where(r => r.PostId == postId)
                          .FirstOrDefaultAsync();


            if (searchedReaction != null)
            {
                this._ctx.Reactions.Remove(searchedReaction);

                var post = await this._ctx.Posts
                        .Where(p => p.PostId == postId)
                        .FirstOrDefaultAsync();

                post.NumberOfReactions--;

                await this._ctx.SaveChangesAsync();

                return true;

            }
            else return false;
        }

        public  async Task<IEnumerable<Reaction>> GetAllReactionsByPost(int postId)
        {
            return await this._ctx.Reactions.
                        Where(r => r.PostId == postId).
                        Include(r=> r.Profile).
                        ToListAsync();
                        
        }

       
    }
}
