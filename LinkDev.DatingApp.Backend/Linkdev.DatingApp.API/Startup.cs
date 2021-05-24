using LinkDev.DatingApp.API.Extensions;
using LinkDev.DatingApp.Application;
using LinkDev.DatingApp.Application.Contracts;
using LinkDev.DatingApp.Application.InfrastuctureContracts;
using LinkDev.DatingApp.Application.PresistenceContracts;
using LinkDev.DatingApp.Infrastructure;
using LinkDev.DatingApp.Presistence;
using LinkDev.DatingApp.Presistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LinkDev.DatingApp.API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            this._config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices(_config);
            services.AddIdentityService(_config);
            services.AddControllers();
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Linkdev.DatingApp.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Linkdev.DatingApp.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors(x=>x.AllowAnyHeader().AllowAnyHeader().WithOrigins("http://localhost:4200"));
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
