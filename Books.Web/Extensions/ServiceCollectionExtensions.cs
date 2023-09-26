using Books.Core.Data;
using Books.Core.Entities;
using Books.Manage.Helpers.FileManager;
using Books.Manage.Helpers.Options;
using Books.Manage.Helpers.Validators;
using Books.Manage.Managers;
using Books.Manage.Managers.Abstractions;
using Books.Manage.Mappers;
using Books.Manage.Mappers.Abstractions;
using Books.Manage.Repositories;
using Books.Manage.Repositories.Abstarctions;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Books.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMyDbContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<BookDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DbConnection"));
        });
        return services;
    }

    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        services.AddScoped<IGenericMapper<CreateBookModel, Book, BookModel>, BookMapper>()
            .AddScoped<IGenericMapper<CreateBookFileModel, BookFile, BookFileModel>, BookFileMapper>()
            .AddScoped<IGenericMapper<CreateBookGenreModel, BookGenre, BookGenreModel>, BookGenreMapper>()
            .AddScoped<IGenericMapper<CreateBookSeriesModel, BookSeries, BookSeriesModel>, BookSeriesMapper>()
            .AddScoped<IGenericMapper<CreateGenreModel, Genre, GenreModel>, GenreMapper>()
            .AddScoped<IGenericMapper<CreateWriterModel, Writer, WriterModel>, WriterMapper>();
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRerpository>()
            .AddScoped<IBookFileRepository, BookFileRepository>()
            .AddScoped<IBookGenreRepository,BookGenreRepository>()
            .AddScoped<IBookSeriesRepository,BookSeriesRepository>()
            .AddScoped<IGenreRepository,GenreRepository>()
            .AddScoped<IWriterRepository,WriterRepository>();
       return services;
    }

    public static IServiceCollection AddManagers(this IServiceCollection services)
    {
        services.AddScoped<IBookFileManager, BookFileManager>()
            .AddScoped<IBookGenreManager, BookGenreManager>()
            .AddScoped<IBookManager, BookManager>()
            .AddScoped<IBookSeriesManager, BookSeriesManager>()
            .AddScoped<IGenreManager, GenreManager>()
            .AddScoped<IWriterManager, WriterManager>();
        return services;
    }

    public static IServiceCollection AddHelpers(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScoped<IFileManager, FileManager>()
            .AddScoped<IGuardian, Guardian>();

        services.Configure<DirectoryOptions>(configuration.GetSection("Directories"));

        services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
        });

        services.AddLocalization(options => options.ResourcesPath = "Resources");

        services.AddMvc()
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization();

        var supportedCultures = new[]
        {
            new CultureInfo("en-US"),
            new CultureInfo("ru-RU"),
            new CultureInfo("uz-Latn")
        };

        services.AddRequestLocalization(option =>
        {
           option.SupportedUICultures = supportedCultures;
           option.SupportedCultures = supportedCultures;
           option.SetDefaultCulture("uz-Latn");
        });

        return services;
    }
}