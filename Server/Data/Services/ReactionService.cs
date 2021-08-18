using Server.Data.Entities;
using Server.Data.IServices;
using System.Collections.Generic;
using System.Linq;

namespace Server.Data.Services
{
    public class ReactionService : IReactionService
    {
        private readonly FungramContext _ctx;

        public ReactionService(FungramContext ctx)
        {
            _ctx = ctx;
        }

        public void AddReaction(Reaction reaction)
        {
            _ctx.Add(reaction);
            _ctx.SaveChanges();
        }

        public IEnumerable<Reaction> GetAllReactionsByPost(int postId)
        {
            return _ctx.Reactions.
                        Where(r => r.PostId == postId).
                        ToList();
        }

        public bool SaveChanges()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
