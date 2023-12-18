using Models;
using Models.DTOs.Create;

namespace Data.Repository.Interfaces;

public interface IPostRepository
{
    List<Post> GetAllPosts();
    Post GetPostById(Guid postId);
    Guid AddPost(Post post);
    void UpdatePost(Post post);
    void DeletePost(Guid postId);
}
