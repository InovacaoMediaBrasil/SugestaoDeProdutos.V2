using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace SugestaoDeProdutos;

/// <summary>
/// Class Startup.
/// </summary>
public class Startup
{
    /// <summary>
    /// Gets the configuration.
    /// </summary>
    /// <value>The configuration.</value>
    public IConfiguration Configuration { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Startup" /> class.
    /// </summary>
    /// <param name="env">The env.</param>
    public Startup(IWebHostEnvironment env)
    {
        if (env == null)
        {
            return;
        }

        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
            .AddUserSecrets<Startup>()
            .AddEnvironmentVariables()
            .AddCommandLine(Environment.GetCommandLineArgs());
        Configuration = builder.Build();
    }

    /// <summary>
    /// Configures the services for the application.
    /// </summary>
    /// <param name="services">The service collection to which services are added.</param>
    /// <remarks>
    /// This method sets up the necessary services for the application, including:
    /// - Adding MVC controllers to the service collection.
    /// - Configuring Swagger for API documentation, specifying the API title, version, description, contact information, and license details.
    /// - Including XML comments for better documentation in the generated Swagger UI.
    /// - Setting up CORS (Cross-Origin Resource Sharing) policies to allow requests from any origin, method, and header.
    /// This configuration is essential for enabling API functionality and ensuring proper documentation and cross-origin requests.
    /// </remarks>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(
                "v2",
                new OpenApiInfo
                {
                    Title = "Sugestão de produtos",
                    Version = "v2",
                    Description =
                        "API de sugestão de produtos da Editora Inova��o / Inovação Media Brasil",
                    Contact = new OpenApiContact
                    {
                        Name = "Guilherme Branco Stracini",
#pragma warning disable S1075
                        Url = new Uri("https://github.com/guibranco"),
#pragma warning restore S1075
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under MIT",
                        Url = new Uri(
#pragma warning disable S1075
                            "https://github.com/InovacaoMediaBrasil/SugestaoDeProdutos/blob/master/LICENSE"
#pragma warning restore S1075
                        ),
                    },
                }
            );

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });

        services.AddCors(o =>
            o.AddPolicy(
                "All",
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            )
        );
    }

    /// <summary>
    /// Configures the specified application.
    /// </summary>
    /// <param name="app">The application.</param>
    /// <param name="env">The env.</param>
    /// <summary>
    /// Configures the application's request pipeline.
    /// </summary>
    /// <param name="app">The application builder used to configure the HTTP request pipeline.</param>
    /// <param name="env">The web hosting environment that provides information about the environment the application is running in.</param>
    /// <remarks>
    /// This method sets up various middleware components in the application's request pipeline based on the hosting environment.
    /// In development mode, it enables the developer exception page for better error visibility.
    /// It also configures CORS (Cross-Origin Resource Sharing), Swagger for API documentation, and HTTPS redirection.
    /// The routing middleware is added to handle incoming requests, and authorization middleware is configured to enforce security policies.
    /// Finally, it sets up endpoint routing to map controller actions to incoming requests.
    /// </remarks>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors();

        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v2/swagger.json", "Sugestão de Produtos v2");
            c.RoutePrefix = string.Empty;
        });

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
