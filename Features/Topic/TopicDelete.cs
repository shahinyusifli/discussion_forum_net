namespace MinimalAPI.Features;


public class TopicDelete : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        
            app.MapGet("/topic/delete", () => "TopicDelete");
        
        
    }
}
