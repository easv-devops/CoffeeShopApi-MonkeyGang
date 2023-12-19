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
            // Arrange
            var expectedPosts = new List<Post> { new Post(), new Post() };
            _postRepositoryMock.Setup(repo => repo.GetAllPosts()).Returns(expectedPosts);

            // Act
            var result = _postService.GetAllPosts();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(expectedPosts));
        }

        [Test]
        public void GetPostById_ExistingId_ShouldReturnPost()
        {
            // Arrange
            var postId = Guid.NewGuid();
            var expectedPost = new Post { PostId = postId };
            _postRepositoryMock.Setup(repo => repo.GetPostById(postId)).Returns(expectedPost);

            // Act
            var result = _postService.GetPostById(postId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(expectedPost));
        }

        [Test]
        public void GetPostById_NonExistingId_ShouldReturnNull()
        {
            // Arrange
            var postId = Guid.NewGuid();
            _postRepositoryMock.Setup(repo => repo.GetPostById(postId)).Returns((Post)null);

            // Act
            var result = _postService.GetPostById(postId);

            // Assert
            Assert.That(result, Is.Null);
        }

    

        [Test]
        public void UpdatePost_ShouldCallUpdatePostInRepository()
        {
            // Arrange
            var postToUpdate = new Post { PostId = Guid.NewGuid(), Title = "Updated Post" };

            // Act
            _postService.UpdatePost(postToUpdate);

            // Assert
            _postRepositoryMock.Verify(repo => repo.UpdatePost(postToUpdate), Times.Once);
        }

        [Test]
        public void DeletePost_ExistingId_ShouldCallDeletePostInRepository()
        {
            // Arrange
            var postId = Guid.NewGuid();

            // Act
            _postService.DeletePost(postId);

            // Assert
            _postRepositoryMock.Verify(repo => repo.DeletePost(postId), Times.Once);
        }
    }