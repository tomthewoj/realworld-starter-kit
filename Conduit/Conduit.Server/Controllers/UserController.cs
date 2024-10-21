
using Conduit.Application.Users.Commands.CreateUser;
using Conduit.Domain.Entities;
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

        [HttpPost("SignUp")]
        public async Task<ActionResult> AddUser(CreateUserCommand user) //createuser jako parametr, createusercommand.create, 
        {
            await _mediator.Send(user);
            return Ok();
        }
    }
}
