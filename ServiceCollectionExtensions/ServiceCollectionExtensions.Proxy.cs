namespace Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DevAcademyAssigment.Models;

public static partial class ServiceCollectionExtensions
{
    public static WebApplicationBuilder AddProxy(
        this WebApplicationBuilder builder)
    {
        string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
            builder =>
        {
            builder.WithOrigins("*");
        });
});

        return builder;
    }
}
