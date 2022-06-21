namespace MinimalAPI.Features;
using DevAcademyAssigment.Models;
using Microsoft.EntityFrameworkCore;


public class DashboardGetMessages : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
            app.MapGet("/dashboard/get/messages/{topicId}", async (MessagesDb db, int topicId) => await db.Topics.Join(
            db.Messages,
            topic => topic.TopicId,
            message => message.TopicId,
            (topic, message) => new
            {
                TopicId = topic.TopicId,
                MessageContent = message.MessageContent,
                TopicContent = topic.TopicContent,
                DateOfMessage = message.Date,
                MessageId = message.MessageId,
            }
        )
.Where(x => x.TopicId==topicId)
.ToListAsync());;
    }
}