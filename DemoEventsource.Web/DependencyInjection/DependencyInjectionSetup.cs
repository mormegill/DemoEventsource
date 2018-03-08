using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoEventsource.Web.DependencyInjection
{
    public static class DependencyInjectionSetup
    {
        public static void DependecyInjection(this IServiceCollection services, IConfiguration config)
        {
            //var dbConfig = new DatabaseConfiguration();
            //config.Bind("Database", dbConfig);
            //services.AddSingleton<IDatabaseConfiguration>(dbConfig);
            //services.AddTransient<IRequestValidator<Models.Request.CreateAdvertRequest>>(x =>
            //    new RequestValidator<Models.Request.CreateAdvertRequest>(new CreateAdvertRequestValidator()));

            services.AddTransient<ISettings, Settings>();
            //services.AddSingleton(CreateEventPublisher(config));
        }
    }
}
