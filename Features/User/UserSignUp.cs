namespace MinimalAPI.Features;
using DevAcademyAssigment.Models;
using System.IdentityModel.Tokens.Jwt;

using System.Text;

using Microsoft.AspNetCore.Authorization;

using Microsoft.IdentityModel.Tokens;


public class UserSignUp : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        

        app.MapPost("/user/signup",
[AllowAnonymous] async (MessagesDb db, User user) =>
{
    var builder = WebApplication.CreateBuilder();


    var issuer = user.UserName;
    var audience = user.Email;
    var securityKey = new SymmetricSecurityKey
(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
    var credentials = new SigningCredentials(securityKey,
SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(issuer: issuer,
        audience: audience,
        signingCredentials: credentials);

    var tokenHandler = new JwtSecurityTokenHandler();
    var stringToken = tokenHandler.WriteToken(token);

    user.HashCode = stringToken;

     await db.Users.AddAsync(user);
          await db.SaveChangesAsync();


});


    }
}
