using Models;

namespace Service;

public interface IPostService
{
    List<Post> GetAllPosts();
    Post GetPostById(Guid postId);
    Guid AddPost(Post post);
    void UpdatePost(Post post);
    void DeletePost(Guid postId);
}