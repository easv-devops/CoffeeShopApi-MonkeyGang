using AutoMapper;
using Models.DTOs;

namespace Models.Utility;

public class PasswordResolver : IValueResolver<CustomerDto, Customer, string>
{
    public string Resolve(CustomerDto source, Customer destination, string member, ResolutionContext context)
    {
        return BCrypt.Net.BCrypt.HashPassword(source.Password, BCrypt.Net.BCrypt.GenerateSalt(12));
    }
}
