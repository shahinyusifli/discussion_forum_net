namespace MinimalAPI.Features;
using DevAcademyAssigment.Models;
using Microsoft.EntityFrameworkCore;



public class  DashboardDelete : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        
            app.MapDelete("/dashboard/delete/{topicId}", async ( MessagesDb db, int topicId) =>
{
    var topicItem = await db.Topics.FindAsync(topicId);
    var messageItem = await db.Messages.FirstOrDefaultAsync(x => x.TopicId == topicId);
    
    if (topicItem is null){
       return Results.NotFound();
    }

    if (messageItem is null) {
        db.Topics.Remove(topicItem);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    
    else {
        db.Topics.Remove(topicItem);
        db.Messages.Remove(messageItem);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
});;    
   }
}
