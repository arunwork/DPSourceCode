using DailyPrice.API.BusinessLogic.Services.Shared;
using DailyPrice.API.Data;
using Microsoft.Extensions.DependencyInjection;

namespace DailyPrice.API.Infrastructure
{
    /// <summary>
    /// Represents DependencyRegistrar for Dependency Injection
    /// </summary>
    public static class DependencyRegistrar
    {
        /// <summary>
        /// Register repository and services
        /// </summary>
        /// <param name="services">Services</param>
        public static void Register(IServiceCollection services)
        {
            //add the generic repository to the service collection
            services.AddSingleton<IRepository, Repository>();

            //add the state service to the service collection
            services.AddTransient<IStateService, StateService>();
        }
    }
}