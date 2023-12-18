using Models;
using Models.DTOs.Create;

namespace Service;

public interface IPostService
{
    List<Post> GetAllPosts();
    Post GetPostById(Guid postId);
    Guid AddPost(CreatePostDto post);
    void UpdatePost(Post post);
    void DeletePost(Guid postId);
}