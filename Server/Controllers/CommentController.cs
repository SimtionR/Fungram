using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Entities;
using Server.Data.IServices;
using Server.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static Server.Extensions.DRY_Functions;

namespace Server.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        private readonly IProfileService _profileService;
        private readonly ICommentService _commentService;

        public CommentController(IProfileService profileService, ICommentService commentService)
        {
            _profileService = profileService;
            _commentService = commentService;
        }

        [HttpPost]
        [Route("{postId}")]
        public async Task<ActionResult> Create(int postId, CommentModel model)
        {
            var profile = await GetPorifleUser(this.User.Claims, _profileService);


            if (profile != null)
            {
                var commnet = await this._commentService.CreateComment(profile.ProfileId, postId, model.CommentBody);

                return Created(nameof(this.Created), commnet);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("{postId}")]
        public async Task<IEnumerable<Comment>> Get(int postId)
        {
            var profile = await GetPorifleUser(this.User.Claims, _profileService);

            if (profile != null)
            {
                var comments = await this._commentService.GetCommentsByPost(postId);
                return comments;

            }

            var emptyComment = new List<Comment>();
            return emptyComment;

        }

        [HttpDelete]
        [Route("{commentId}")]
        public async Task<ActionResult> Delete (int commentId)
        {
            var profile = await GetPorifleUser(this.User.Claims, _profileService);

            if (profile != null)
            {
                var comment = await this._commentService.Delete(commentId, profile.ProfileId);

                if (!comment)
                    return BadRequest();

                else return Ok();
            }
            return BadRequest();

        }
        
    }
}
