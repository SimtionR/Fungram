using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Entities;
using Server.Data.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Server.Extensions.DRY_Functions;

namespace Server.Controllers
{

    [Authorize]
    public class ReactionController : ApiController
    {

        private readonly IProfileService _profileService;
        private readonly ICommentService _commentService;
        private readonly IReactionService _reactionService;
        private readonly IPostService _postService;
        private const string reactionImg = "https://coollogo.net/wp-content/uploads/2021/02/Facebook-Reaction-Like-logo.svg";

        public ReactionController(IProfileService profileService,
            ICommentService commentService,
            IReactionService reactionService,
            IPostService postService)
        {
            _profileService = profileService;
            _commentService = commentService;
            _reactionService = reactionService;
            _postService = postService;
        }

        [HttpPost]
        [Route("{postId}")]
        public async Task<ActionResult> PostReaction(int postId)
        {
            var profile = await GetPorifleUser(this.User.Claims, _profileService);

            var post = await this._postService.GetPostById(postId);

            if (profile != null)
            {
                var reaction = await this._reactionService.Create(reactionImg, profile.ProfileId, postId, post);
                return Created(nameof(this.Created), reaction);
            }

            else return BadRequest();
        }


        [HttpDelete]
        [Route("{postId}")]
        public async Task<ActionResult> Delete(int postId)
        {
            var profile = await GetPorifleUser(this.User.Claims, _profileService);

            if (profile != null)
            {
                var reaction = await this._reactionService.Delete(postId);

                if (!reaction)
                {
                    return BadRequest();
                }
                return Ok();
            }

            return BadRequest();
        }


        [HttpGet]
        [Route("{postId}")]
        public async Task<IEnumerable<Reaction>> Get(int postId)
        {
            var profile = await GetPorifleUser(this.User.Claims, _profileService);

         

            if (profile != null)
            {
                var reactions = await this._reactionService.GetAllReactionsByPost(postId);

                return reactions;
            }

             var emptyReaction = new List<Reaction>();
                return emptyReaction;
        }
    }

 
        

}
