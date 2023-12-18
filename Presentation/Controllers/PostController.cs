using AutoMapper;
using Models.DTOs;
using Models.DTOs.Create;

namespace Presentation.Controllers;


using Microsoft.AspNetCore.Mvc;
using Models; // Assuming your Post model is in a "Models" namespace
using Service; // Assuming you have a service for managing posts

[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;
    private readonly IMapper _mapper;

    public PostController(IPostService postService, IMapper mapper)
    {
        _postService = postService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllPosts()
    {
        var posts = _postService.GetAllPosts();
        
        List<PostDto> postDtos = _mapper.Map<List<PostDto>>(posts);
        
        return Ok(postDtos);
    }

    [HttpGet("{postId}")]
    public IActionResult GetPostById(Guid postId)
    {
        var post = _postService.GetPostById(postId);

        if (post == null)
            return NotFound();
        
        PostDto postDto = _mapper.Map<PostDto>(post);

        return Ok(postDto);
    }

    [HttpPost]
    public IActionResult CreatePost([FromBody] CreatePostDto post)
    {
        if (post == null)
            return BadRequest();

        var createdPostId = _postService.AddPost(post);

        return CreatedAtAction(nameof(GetPostById), new { postId = createdPostId }, post);
    }

    [HttpPut("{postId}")]
    public IActionResult UpdatePost(Guid postId, [FromBody] Post post)
    {
        if (post == null || postId != post.PostId)
            return BadRequest();

        _postService.UpdatePost(post);

        return NoContent();
    }

    [HttpDelete("{postId}")]
    public IActionResult DeletePost(Guid postId)
    {
        var post = _postService.GetPostById(postId);

        if (post == null)
            return NotFound();

        _postService.DeletePost(postId);

        return NoContent();
    }
}
