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
        app.MapGet("/topic/get", [Authorize] (MessagesDb db) => db.Topics.Join(
            db.Messages,
            topic => topic.TopicId,
            message => message.TopicId,
            (topic, message) => new
            {
                MessageId = message.MessageId,
                MessageName = message.MessageContent,
                TopicName = topic.TopicContent,
                messageDate = message.Date,
                TopicId = topic.TopicId,
                UserId = message.UserId,
                userName = db.Users.FirstOrDefault(x => x.UserId == message.UserId).UserName,
                userRole = db.Users.FirstOrDefault(x => x.UserId == message.UserId).Role
            }
        ).ToList());
    }
}
