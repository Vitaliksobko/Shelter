using System.Security.Claims;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shelter.Application.Abstractions;
using Shelter.Core.Dtos;
using Shelter.Core.Models;

namespace Shelter.Api.Controllers;
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthorizationService _authorizationService;

    public AuthController(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<Guid>> Login([FromBody] LoginDto request)
    {
        try
        {
            var id = await _authorizationService.LoginUser(request);

            return Ok(id);
        }
        catch (Exception e)
        {
            return Unauthorized(e.Message);
        }
    }

    [HttpPost("registration")]
    public async Task<ActionResult<Guid>> Registration([FromBody] RegistrationDto request)
    {
        try
        {
            var id = await _authorizationService.RegisterUser(request);

            return Ok(id);
        }
        catch (Exception e)
        {
            return Unauthorized(e.Message);
        }
    }
}