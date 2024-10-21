using Conduit.Application.Exceptions;
using Conduit.Domain.Entities;
using Conduit.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Conduit.Application.Users.Commands.CreateUser;

internal class CreateUserCommandHandler(ILogger<CreateUserCommandHandler> log, IUserRepository userRepository, UserManager<User> userManager) : IRequestHandler<CreateUserCommand>
{
    private readonly UserManager<User> _userManager = userManager;


    public async Task Handle(CreateUserCommand request, CancellationToken cancelationToken) // abort execution with the token, na wszelki wypadek try catch, middleware do łapania, loguj wszystko na wszelki wypadek
    {
        
        if (await userRepository.UsernameExistsAsync(request.Username))
        {
            throw new UsernameAlreadyExistsException(request.Username);
        }
        if (await userRepository.EmailExistsAsync(request.Email))
        {
            throw new EmailAlreadyExistsException(request.Email);
        }
        //do środka usera
        var NewUser = new User
        {
            UserName = request.Username,
            Email = request.Email,
            CreatedAt = DateTime.Now
        };
        var result = await _userManager.CreateAsync(NewUser, request.Password);
    }
}
