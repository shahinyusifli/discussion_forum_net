namespace MinimalAPI.Features;
using DevAcademyAssigment.Models;
using Microsoft.EntityFrameworkCore;


public class DashboardGet : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        
            app.MapGet("/dashboard/get", async (MessagesDb db) => await db.Topics.Join(
            db.Messages,
            topic => topic.TopicId,
            message => message.TopicId,
            (topic, message) => new
            {
                TopicId = topic.TopicId,
                MessageName = message.MessageContent,
                TopicName = topic.TopicContent,
                DateOfMessage = message.Date,


            }
        ).GroupBy(topic => topic.TopicName)
.Select(
  messageGroup => new {
    TopicId = messageGroup.Select(a => a.TopicId).FirstOrDefault(),
     TopicName = messageGroup.Key, TotalMessages = messageGroup.Count(),
     TimeOfLastMessage = messageGroup.Min(f => f.DateOfMessage) 

     }
).OrderBy(time => time.TimeOfLastMessage)
.ToListAsync());;
    }
}
