namespace Models.DTOs.Create;

public class CreatePostDto
{
    public string Title { get; set; }
    public string Text { get; set; }
    public Guid userId { get; set; }
    
}