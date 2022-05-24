namespace MinimalAPI.Features;
using DevAcademyAssigment.Models;
using System.IdentityModel.Tokens.Jwt;

using System.Text;

using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;





public class TopicGet : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/topic/get", [Authorize(Roles="admin")] (MessagesDb db) => db.Topics.Join(
            db.Messages,
            topic => topic.TopicId,
            message => message.TopicId,
            (topic, message) => new
            {
                TopicId = topic.TopicId,
                MessageName = message.MessageContent,
                TopicName = topic.TopicContent
            }
        ).ToList());
    }
}
