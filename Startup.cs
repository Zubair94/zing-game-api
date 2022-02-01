using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZingGameApi.Data;
using ZingGameApi.Configurations;

namespace ZingGameApi;

public class Startup
{
    private readonly IConfiguration _configuration;
    
    public Startup(IConfiguration configuration)
    {
        var envPath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
        EnvironmentConfiguration.LoadEnvironment(envPath);
        _configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<DataContext>(dbContextOptions =>
        {
            dbContextOptions.UseNpgsql(EnvironmentConfiguration.GetDbConnectionString(), 
                pgSqlOptions => pgSqlOptions.UseNetTopologySuite());
        });
        services.AddApiVersioning(apiVersioningOptions => {
            apiVersioningOptions.AssumeDefaultVersionWhenUnspecified = false;
            apiVersioningOptions.ReportApiVersions = true;
            apiVersioningOptions.DefaultApiVersion = new ApiVersion(1, 0);
            apiVersioningOptions.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Api-Version"),
                new MediaTypeApiVersionReader("v"),
                new QueryStringApiVersionReader("api-version")
            ); 
        })
        .AddVersionedApiExplorer(apiExplorerOptions => {
             apiExplorerOptions.GroupNameFormat = "'v'VVV";
             apiExplorerOptions.SubstituteApiVersionInUrl = true;
        });
        services.AddControllers();
        services.AddSwaggerGen();
        services.ConfigureOptions<ConfigureSwaggerOptions>();
        
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(swaggerOptions =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    swaggerOptions.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json", 
                        description.GroupName.ToUpperInvariant());
                }
            });
        }

        // app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
