namespace MinimalAPI.Features;
using DevAcademyAssigment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;



public class DashboardUpdate : ICarterModule
{
     
    public void AddRoutes(IEndpointRouteBuilder app)
    {
       

        app.MapPut("/dashboard/update/{topicId}",[Authorize(Roles = "admin")] async (MessagesDb db, Topic updateTopic, int topicId) =>
{
    var topicItem = await db.Topics.FindAsync(topicId);
    var messageItem = await db.Messages.FirstOrDefaultAsync(x => x.TopicId == topicId);

    if (topicItem is null){
        
        return Results.NotFound();
    }
    if (messageItem is null){
        
        return Results.NotFound();
    }
    else {
        topicItem.TopicContent = updateTopic.TopicContent;
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    
   
    
});


    }
}
