namespace Models.DTOs;

public class CoffeeCupDto : ItemDto
{
    public int Size { get; set; }
    //TODO: make decision about this property
    public CustomerDto? Customer { get; set; }
    
}