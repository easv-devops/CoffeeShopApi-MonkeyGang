using Data.Repository.Interfaces;
using Models;
using Service;

namespace Business.Service;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;

    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public List<Post> GetAllPosts()
    {
        return _postRepository.GetAllPosts();
    }

    public Post GetPostById(Guid postId)
    {
        return _postRepository.GetPostById(postId);
    }

    public Guid AddPost(Post post)
    {
        // Add any additional business logic/validation here before calling the repository method
        // For example, you might want to validate the content of the post before saving it.

        return _postRepository.AddPost(post);
    }

    public void UpdatePost(Post post)
    {
        // Add any additional business logic/validation here before calling the repository method

        _postRepository.UpdatePost(post);
    }

    public void DeletePost(Guid postId)
    {
        // Add any additional business logic/validation here before calling the repository method

        _postRepository.DeletePost(postId);
    }
}