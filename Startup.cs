using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Repositories;

namespace Project.Startup;
public class Startup
{

    string _MyAllowSpecificOrigins = nameof(_MyAllowSpecificOrigins);
    WebApplicationBuilder Builder = WebApplication.CreateBuilder();

    public Startup()
    {
        Builder = WebApplication.CreateBuilder();
    }
    public void ConfigureServices(IServiceCollection services)
    {
        string connectionString = Builder.Configuration.GetConnectionString("defaultConnection");
        services.AddCors(options =>
         options.AddPolicy(_MyAllowSpecificOrigins, policy =>
          policy.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod()));
        services.AddControllers();
        services.AddDbContext<DatabaseContext>(options =>
            options.UseMySql(connectionString, MySqlServerVersion.AutoDetect(connectionString))
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        services.AddSwaggerGen();
        services.AddScoped<UnitOfWork>();
        services.AddScoped<ICustomerRepository, MemCustomerRepository>();
        services.AddScoped<IPropertyRepository, PropertyRepository>(c => ActivatorUtilities.CreateInstance<PropertyRepository>(c));
        // services.AddSingleton<List<Customer>>();

    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }
        else
        {
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseCors(_MyAllowSpecificOrigins);
        app.UseRouting();
        app.UseEndpoints(endPoints => endPoints.MapControllers());
    }
}