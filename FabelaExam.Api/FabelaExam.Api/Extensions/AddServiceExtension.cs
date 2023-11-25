using FabelaExam.Business.Implementations;
using FabelaExam.Business.DataContext;
using FabelaExam.Business.Settings;
using Microsoft.EntityFrameworkCore;
using FabelaExam.Business.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FabelaExam.Api.Extensions
{
    public static class AddServiceExtension
    {
        public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IAuthorizer, AuthorizerService>();
            services.AddTransient<IUser, UserService>();
            services.AddTransient<ISettings, SettingServices>(); 

            return services;
        }
    }
}
