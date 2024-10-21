
namespace Conduit.Application.Users.DTOs;

public class UserDto //alternatively, play around with public record LoginUserDTO(string Email, string Password);
{
    public Guid Id { get; set; }
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Email { get; set; } = default!;
    
}
