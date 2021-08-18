using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Data.IServices;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controllers
{
    public class PostController : ApiController
    {
        private readonly IPostService _postService;
        private readonly IProfileService _profileService;

        public PostController(IPostService postService, IProfileService profileService)
        {
            _postService = postService;
            _profileService = profileService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePost(PostModel model)
        {
            var userId = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;


            var profile =_profileService.GetProfileByUser(userId);


            if(profile!= null)
            {
                var post = await this._postService.CreatePost(
                    model.ImageUrl, model.Description, profile.ProfileId);

                return Created(nameof(this.Created), post);
            }

            return BadRequest();

        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<FeedListModel>> Feed()
        {
            var userId = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;


            var profile = _profileService.GetProfileByUser(userId);

            if (profile != null)
            {
                var feed = await this._postService.GetProfileFeed(profile.ProfileId);

                return feed;

            }
            else
            {
                var emptyFeed = new List<FeedListModel>();

                return emptyFeed;
            }

            
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PostDetailModel>> DetailedPost(int id)
        {
            var post = await this._postService.GetDetailedPost(id);

            if(post == null)
            {
                return this.NotFound();
            }

            return post;
        }


        /*[HttpPut]
        public async Task<ActionResult> Update(UpdatePost model)
        {
            var userId = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;


            var profile = _profileService.GetProfileByUser(userId);

            if (profile !=null)
            {
                //if(model.PostId )
            }

        }*/



    }
}
    