using LinkDev.DatingApp.Application;
using LinkDev.DatingApp.Application.Contracts;
using LinkDev.DatingApp.Application.InfrastuctureContracts;
using LinkDev.DatingApp.Application.PresistenceContracts;
using LinkDev.DatingApp.Infrastructure;
using LinkDev.DatingApp.Presistence;
using LinkDev.DatingApp.Presistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LinkDev.DatingApp.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUsersManager, UsersManager>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<ITokenService>(_ => new TokenService(config["SecurityKey"]));
            services.AddDbContext<DatingAppContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}