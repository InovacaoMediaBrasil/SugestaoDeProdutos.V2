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
    /// Configures the services for the application, including setting up controllers, Swagger documentation, and CORS policy.
    /// </summary>
    /// <param name="services">The service collection to which services are added.</param>
    /// <remarks>
    /// This method is responsible for configuring various services required by the application.
    /// It adds support for MVC controllers, sets up Swagger for API documentation, and configures a CORS policy
    /// that allows any origin, method, and header. The Swagger documentation is configured with metadata
    /// such as title, version, description, contact information, and license details.
    /// Additionally, it includes XML comments for better documentation of the API endpoints.
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

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    /// <summary>
    /// Configures the specified application.
    /// </summary>
    /// <param name="app">The application.</param>
    /// <param name="env">The env.</param>
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
