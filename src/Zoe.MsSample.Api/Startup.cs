using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Zoe.MsSample.Api.Configuration;

namespace Zoe.MsSample.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationMessageConfig(this.Configuration);
            services.AddAutoMapperConfig();
            services.AddDatabaseConfig();
            services.AddDependenciesConfig();
            services.AddDomainToolsConfig();
            services.AddFailFastValidationPipelineConfig();
            services.AddSwaggerConfig();
            services.AddVersioningConfig();
            services.AddMvcConfig();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseSwaggerConfig();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
