namespace Models;

public class Customer
{
    
    public Customer()
    {
        CustomerId = Guid.NewGuid();
    }
    
    public Guid CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    
    private string _passwordHash;

    //BCrypt gemmer salten for os
    public string Password
    {
        get => _passwordHash;
        set => _passwordHash = BCrypt.Net.BCrypt.HashPassword(value, BCrypt.Net.BCrypt.GenerateSalt(12)); //hvis programmet er langsomt kan vi sætte workFactor ned
    }
    

    // Navigation property for the one-to-many relationship
    public List<Order> Orders { get; set; }
    public List<Post> Posts { get; set; }
    
    public bool IsPasswordCorrect(string enteredPassword)
    {
        return BCrypt.Net.BCrypt.Verify(enteredPassword, _passwordHash);
    }
    
}