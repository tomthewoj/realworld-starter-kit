using Conduit.Application.Entities;
using Conduit.Application.Users.Commands.CreateUser;
using Conduit.Application.Users.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Conduit.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator) => _mediator = mediator;

        [HttpPost("SignIn")]
        public async Task<ActionResult> AddUser([FromBody] User user) //createuser jako parametr, createusercommand.create, 
        {
            await _mediator.Send(new CreateUserCommand
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password
            });
            return Ok();
        }
    }
}
