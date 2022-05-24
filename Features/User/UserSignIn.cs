namespace MinimalAPI.Features;
using DevAcademyAssigment.Models;
using System.IdentityModel.Tokens.Jwt;

using System.Text;

using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;


public class UserSignIn : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {


        app.MapPost("/user/sigin",
[AllowAnonymous] (User user, MessagesDb db) =>
{
    var builder = WebApplication.CreateBuilder();

    if (db.Users.Any(c => c.UserName == user.UserName && c.Password == user.Password))
    {

        var role = db.Users.Where(c => c.UserName == user.UserName && c.Password == user.Password)
                                          .Select(s => 
                                          
                                              $"Role = {s.Role}"    
                                          ).FirstOrDefault();

        

        var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, role),
                };

        var issuer = builder.Configuration["Jwt:Issuer"];
        var audience = builder.Configuration["Jwt:Audience"];
        var securityKey = new SymmetricSecurityKey
    (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey,
    SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(issuer: issuer,
            audience: audience,
            signingCredentials: credentials,
            claims: authClaims,
            expires: DateTime.Now.AddHours(3));

        var tokenHandler = new JwtSecurityTokenHandler();
        var stringToken = tokenHandler.WriteToken(token);

        return Results.Ok(stringToken);
    }
    else
    {
        return Results.Unauthorized();
    }
});
    }
}
