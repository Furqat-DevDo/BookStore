using Books.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Books.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services,IConfiguration configuration)
    {

        services.AddDbContext<BookDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DbConnection"));
        });
        return services;
    }
}