namespace MinimalAPI.Features;
using DevAcademyAssigment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

public class DashboardGet : ICarterModule
{

    public void AddRoutes(IEndpointRouteBuilder app)
    { 
            app.MapGet("/dashboard/get", [Authorize] async (MessagesDb db) => 
            await db.Topic_Gets.FromSqlRaw("SELECT t0.TopicId, t0.TopicContent, Count(MessageContent)as TotalMessages, m0.Date as TimeOfLastMessage FROM Topics AS t0 LEFT JOIN Messages AS m0 ON t0.TopicId = m0.TopicId Group By t0.TopicContent ORDER BY m0.date")
            .OrderBy(time => time.TimeOfLastMessage)
            .ToListAsync());
    }
}

