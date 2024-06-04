using Shelter.Core.Dtos;

namespace Shelter.Application.Abstractions;

public interface IAuthorizationService
{
    Task<UserIdDto> LoginUser(LoginDto loginDto);
    Task<Guid> RegisterUser(RegistrationDto registrationDto);
}