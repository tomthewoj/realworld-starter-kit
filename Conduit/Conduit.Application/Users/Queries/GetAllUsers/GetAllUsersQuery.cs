using Conduit.Application.Users.DTOs;
using MediatR;
namespace Conduit.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {

    }
}
