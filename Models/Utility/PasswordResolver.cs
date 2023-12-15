using AutoMapper;
using Models.DTOs;

namespace Models.Utility;

public class PasswordResolver : IValueResolver<UserDto, User, string>
{
    public string Resolve(UserDto source, User destination, string member, ResolutionContext context)
    {
        return BCrypt.Net.BCrypt.HashPassword(source.Password, BCrypt.Net.BCrypt.GenerateSalt(12));
    }
}
