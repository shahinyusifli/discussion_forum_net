namespace MinimalAPI.Features;
using DevAcademyAssigment.Models;
using Microsoft.EntityFrameworkCore;


public class TopicUpdates : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/topic/update/{messageId}", async (MessagesDb db, Message updateMessage, int messageId) =>
{
    var messageItem = await db.Messages.FindAsync(messageId);
    
    if (messageItem is null){
        
        return Results.NotFound();
    }
    
    else {
        messageItem.MessageContent = updateMessage.MessageContent;
    
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    
    
});

    }
}