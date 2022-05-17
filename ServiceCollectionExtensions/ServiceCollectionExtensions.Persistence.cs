namespace Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DevAcademyAssigment.Models;

public static partial class ServiceCollectionExtensions
{
    public static WebApplicationBuilder AddStorage(
        this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("messages") ?? "Data Source=Model\\messages.db";
        builder.Services.AddDbContext<MessagesDb>(options => options.UseSqlite(connectionString));

        return builder;
    }
}
