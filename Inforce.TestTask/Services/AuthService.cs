using System.Security.Authentication;
using System.Security.Claims;
using Inforce.TestTask.Abstractions.Services;
using Inforce.TestTask.Dtos;
using Inforce.TestTask.Models;
using Inforce.TestTask.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Inforce.TestTask.Services;

public class AuthService : IAuthService
{
    private readonly SignInManager<User> signInManager;
    private readonly ITokenService tokenService;
    private readonly UserManager<User> userManager;

    public AuthService(ITokenService tokenService, UserManager<User> userManager,
        SignInManager<User> signInManager)
    {
        this.tokenService = tokenService;
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    public async Task<string> RegisterUser(RegisterDto request)
    {
        var registerModel = new RegisterModel
        {
            Email = request.Email,
            Password = request.Password
        };

        var userByEmail = await userManager.FindByEmailAsync(registerModel.Email);

        if (userByEmail != null)
            throw new AuthenticationException("User already exist");

        var userName = registerModel.Email.Substring(0, registerModel.Email.IndexOf("@"));

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = registerModel.Email,
            UserName = userName
        };

        var result = await userManager.CreateAsync(user, registerModel.Password);

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "User");

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Email, user.Email),
                new(JwtRegisteredClaimNames.Jti, user.Id.ToString())
            };

            var roles = await userManager.GetRolesAsync(user);
            tokenService.AddRolesToClaims(authClaims, roles);

            return tokenService.CreateToken(authClaims);
        }

        throw new Exception("An error occurred during processing");
    }

    public async Task<string> LoginUser(LoginDto request)
    {
        var loginModel = new LoginModel
        {
            Email = request.Email,
            Password = request.Password
        };

        var userByEmail = await userManager.FindByEmailAsync(loginModel.Email);

        if (userByEmail == null)
            throw new AuthenticationException("User doesn't exist");

        var result = await signInManager
            .PasswordSignInAsync(userByEmail.UserName, loginModel.Password,
                false, false);

        if (!result.Succeeded)
            throw new AuthenticationException("Wrong pass");

        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Email, loginModel.Email),
            new(JwtRegisteredClaimNames.Jti, userByEmail.Id.ToString())
        };

        var roles = await userManager.GetRolesAsync(userByEmail);
        tokenService.AddRolesToClaims(authClaims, roles);

        var token = tokenService.CreateToken(authClaims);

        await userManager.UpdateAsync(userByEmail);

        return token;
    }
}