namespace MinimalAPI.Features;
using DevAcademyAssigment.Models;
using System.IdentityModel.Tokens.Jwt;

using System.Text;

using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

public class TopicGetName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/topic/get/name", [Authorize] (MessagesDb db) => db.Topics.ToList());
    }
}
