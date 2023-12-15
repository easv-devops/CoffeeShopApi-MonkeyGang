namespace Presentation.Controllers;


using Microsoft.AspNetCore.Mvc;
using Models; // Assuming your Post model is in a "Models" namespace
using Service; // Assuming you have a service for managing posts

[ApiController]
[Route("api/posts")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public IActionResult GetAllPosts()
    {
        var posts = _postService.GetAllPosts();
        return Ok(posts);
    }

    [HttpGet("{postId}")]
    public IActionResult GetPostById(Guid postId)
    {
        var post = _postService.GetPostById(postId);

        if (post == null)
            return NotFound();

        return Ok(post);
    }

    [HttpPost]
    public IActionResult CreatePost([FromBody] Post post)
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
