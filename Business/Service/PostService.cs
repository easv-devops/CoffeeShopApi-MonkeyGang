using AutoMapper;
using Data.Repository.Interfaces;
using Models;
using Models.DTOs.Create;
using Service;

namespace Business.Service;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public List<Post> GetAllPosts()
    {
        return _postRepository.GetAllPosts();
    }

    public Post GetPostById(Guid postId)
    {
        return _postRepository.GetPostById(postId);
    }

    public Guid AddPost(CreatePostDto postdto)
    {
        Post post = _mapper.Map<Post>(postdto);

        return _postRepository.AddPost(post);
    }

    public void UpdatePost(Post post)
    {
        _postRepository.UpdatePost(post);
    }

    public void DeletePost(Guid postId)
    {
        _postRepository.DeletePost(postId);
    }
}