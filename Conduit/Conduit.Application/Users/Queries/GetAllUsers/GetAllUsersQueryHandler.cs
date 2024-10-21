using Conduit.Application.Users.DTOs;
using Conduit.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler(ILogger<GetAllUsersQueryHandler> logger, IUserRepository userRepository) : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetUsersAsync();
            var userDtos = new List<UserDto>();
            foreach(var user in users)
            {
                userDtos.Add(new UserDto
                {
                    Username = user.UserName,
                    Email = user.Email,
                    Id = user.Id,
                });
            }
            return userDtos;
        }
    }
}
