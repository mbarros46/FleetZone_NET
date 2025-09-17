using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MottuCrudAPI.Infrastructure;
using System.Reflection;
using Swashbuckle.AspNetCore.Filters;
using MottuCrudAPI.DTO.Request;
using MottuCrudAPI.WebApi.SwaggerExamples;

namespace MottuCrudAPI
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5049", "https://localhost:7208")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FleetZone API",
                    Version = "v1"
                });
                
                // XML comments
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), includeControllerXmlComments: true);

                // Examples
                c.ExampleFilters();
                
                // Evita colisão de nomes
                c.CustomSchemaIds(t => t.FullName?.Replace('+', '.'));
            });

            // registra exemplos que você criou
            builder.Services.AddSwaggerExamplesFromAssemblyOf<PatioRequestExample>();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
            });

            var app = builder.Build();

            // Deve estar antes do UseAuthorization e MapControllers
            app.UseCors("AllowLocalhost");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FleetZone API v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

    }
}

namespace MottuCrudAPI
{
    public partial class Program { }
}
