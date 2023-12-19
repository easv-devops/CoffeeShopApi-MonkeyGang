using AutoMapper;
using Business.Service;
using Data.Repository.Interfaces;
using Models;
using Models.DTOs.Create;
using Moq;
using NUnit.Framework;
using Service;

namespace CoffeeShopApiTests;

[TestFixture]
public class PostServiceTests
{
    private Mock<IPostRepository> _postRepositoryMock;
    private IPostService _postService;
    private Mock<IMapper> _mapperMock;

    [SetUp]
    public void Setup()
    {
        _postRepositoryMock = new Mock<IPostRepository>();
        _mapperMock = new Mock<IMapper>();

        _postService = new PostService(_postRepositoryMock.Object, _mapperMock.Object);
    }

    [Test]
    public void GetAllPosts_ShouldReturnListOfPosts()
    {
        var expectedPosts = new List<Post> { new Post(), new Post() };
        _postRepositoryMock.Setup(repo => repo.GetAllPosts()).Returns(expectedPosts);

        var result = _postService.GetAllPosts();

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.EqualTo(expectedPosts));
    }

    [Test]
    public void GetPostById_ExistingId_ShouldReturnPost()
    {
        var postId = Guid.NewGuid();
        var expectedPost = new Post { PostId = postId };
        _postRepositoryMock.Setup(repo => repo.GetPostById(postId)).Returns(expectedPost);

        var result = _postService.GetPostById(postId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.EqualTo(expectedPost));
    }

    [Test]
    public void GetPostById_NonExistingId_ShouldReturnNull()
    {
        var postId = Guid.NewGuid();
        _postRepositoryMock.Setup(repo => repo.GetPostById(postId)).Returns((Post)null);

        var result = _postService.GetPostById(postId);

        Assert.That(result, Is.Null);
    }


    [Test]
    public void UpdatePost_ShouldCallUpdatePostInRepository()
    {
        var postToUpdate = new Post { PostId = Guid.NewGuid(), Title = "Updated Post" };

        _postService.UpdatePost(postToUpdate);

        _postRepositoryMock.Verify(repo => repo.UpdatePost(postToUpdate), Times.Once);
    }

    [Test]
    public void DeletePost_ExistingId_ShouldCallDeletePostInRepository()
    {
        var postId = Guid.NewGuid();

        _postService.DeletePost(postId);

        _postRepositoryMock.Verify(repo => repo.DeletePost(postId), Times.Once);
    }
}