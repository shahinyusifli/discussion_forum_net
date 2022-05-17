namespace MinimalAPI.Features;


public class UserGetToken : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        
            app.MapPost("/minimalapi/security/getToken", 
[AllowAnonymous](User user) =>
{

    if (user.UserName=="user1" && user.Password=="password1")
    {
        var issuer = builder.Configuration["Jwt:Issuer"];
        var audience = builder.Configuration["Jwt:Audience"];
        var securityKey = new SymmetricSecurityKey
    (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, 
SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(issuer: issuer,
            audience: audience,
            signingCredentials: credentials);

        var tokenHandler = new JwtSecurityTokenHandler();
        var stringToken = tokenHandler.WriteToken(token);

        return Results.Ok(stringToken);
    }
    else
    {
        return Results.Unauthorized();
    }
});
        
        
    }
}
