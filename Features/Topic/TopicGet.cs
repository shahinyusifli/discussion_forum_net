namespace MinimalAPI.Features;
using DevAcademyAssigment.Models;
using Microsoft.EntityFrameworkCore;


public class TopicGet : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/topic/get", (MessagesDb db) => db.Topics.Join(
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
