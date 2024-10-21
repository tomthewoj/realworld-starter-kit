using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Application.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest //could be a record if I didn't use MediatR
{   
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Email { get; set; } = default!;
}

