namespace Models.DTOs.Response;

public class PostResponseDto
{
    public Guid PostId { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public Guid userId { get; set; }
}