namespace MinimalAPI.Features;
using DevAcademyAssigment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

public class TopicPost : ICarterModule
{


  
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/topic/post", [Authorize] async (Topic topic, MessagesDb db) =>
        {
           
            await db.Topics.AddAsync(topic);
            await db.SaveChangesAsync();
            return Results.Created($"/topic/get/{topic.TopicId}", topic);
        });
    }
}
