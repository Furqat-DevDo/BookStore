using Books.Core.Data;
using Books.Manage.Helpers.Options;
using Microsoft.EntityFrameworkCore;

namespace Books.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<DirectoryOptions>(configuration.GetSection("Directories"));

        services.AddDbContext<BookDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DbConnection"));
        });
        return services;
    }
}