using Server.Data.Entities;
using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Data.IServices
{
    public interface IPostService
    {
        public Task<IEnumerable<FeedListModel>> GetProfileFeed(int profileId);
        public Task<PostDetailModel> GetDetailedPost(int postId);
        IEnumerable<Post> GetPostsByProfile(int profileId);
        public Task<bool> Update(int id, string description, int profileId);
        public Task<Post>GetPostById(int postId);
        void AddPost(Post post);
        public  Task<int> CreatePost(string imageUrl, string Description, int profileId);
        public Task<bool> Delete(int postId, int profileId);
        bool SaveChanges();

    }
}
