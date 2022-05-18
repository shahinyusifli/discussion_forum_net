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
        
          await db.Users.AddAsync(user);
          await db.SaveChangesAsync();
});

    }
}
