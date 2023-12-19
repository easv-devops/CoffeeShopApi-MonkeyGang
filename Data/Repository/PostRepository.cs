using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTOs.Create;

namespace Data.Repository;

public class PostRepository : IPostRepository
{
    private readonly CoffeeShopDbContext _dbContext;

    public PostRepository(CoffeeShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Post> GetAllPosts()
    {
        return _dbContext.Posts.ToList();
    }

    public Post GetPostById(Guid postId)
    {
        return _dbContext.Posts.Find(postId);
    }

    public Guid AddPost(Post post)
    {
        _dbContext.Posts.Add(post);
        _dbContext.SaveChanges();

        return post.PostId;
    }

    public void UpdatePost(Post post)
    {
        _dbContext.Entry(post).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeletePost(Guid postId)
    {
        var post = _dbContext.Posts.Find(postId);

        if (post != null)
        {
            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();
        }
    }
}