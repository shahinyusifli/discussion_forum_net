namespace MinimalAPI.Features;
using DevAcademyAssigment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

public class DashboardPost : ICarterModule
{

      public class Message_from_frontend
  {
      public int MessageId { get; set; }
      public string? messageName { get; set; }
      public DateTime? Date { get; set;  }
      public string? topicName { get; set; }
      public string? userName { get; set; }
    
  }
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/dashbaord/post", [Authorize] async (Message_from_frontend message, MessagesDb db) =>
        {
            var db_message = new Message(); 

           db_message.Date = DateTime.Now;
           db_message.MessageContent = message.messageName;
           db_message.TopicId = db.Topics.FirstOrDefault(x => x.TopicContent == message.topicName).TopicId;
           db_message.UserId = db.Users.FirstOrDefault(x => x.UserName == message.userName).UserId;

            await db.Messages.AddAsync(db_message);
            await db.SaveChangesAsync();
            return Results.Created($"/topic/get/{message.MessageId}", message);
        });
    }
}
