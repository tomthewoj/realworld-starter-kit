using Conduit.Application.Entities;
using Conduit.Application.Exceptions;
using Conduit.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Conduit.Application.Users.Commands.CreateUser;

internal class CreateUserCommandHandler(ILogger<CreateUserCommandHandler> log, IUserRepository userRepository) : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancelationToken) // abort execution with the token, na wszelki wypadek try catch, middleware do łapania, loguj wszystko na wszelki wypadek
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
            Username = request.Username,
            Password = request.Password,
            Email = request.Email,
            CreatedAt = DateTime.Now
        };

        Guid id = await userRepository.AddUserAsync(NewUser);
        return id;
    }
}
