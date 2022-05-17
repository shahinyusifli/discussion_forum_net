namespace MinimalAPI.Features;
using DevAcademyAssigment.Models;
using Microsoft.EntityFrameworkCore;

public class DashboardPost : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/dashbaord/post", async (Message message, MessagesDb db) =>
        {
           Console.WriteLine("hello: "+message.MessageId);
            await db.Messages.AddAsync(message);
            await db.SaveChangesAsync();
            return Results.Created($"/topic/get/{message.MessageId}", message);
        });
    }
}
