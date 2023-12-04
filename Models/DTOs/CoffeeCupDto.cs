
using Models.DTOs;

namespace Models.DTOs;

public class CoffeeCupDto : ItemDto
{
    public int Size { get; set; }
    public CustomerDto? Customer { get; set; }
    // Additional properties specific to CoffeeCupDTO...
}