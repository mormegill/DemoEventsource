using Microsoft.Extensions.Configuration;

namespace DemoEventsource.Web.DependencyInjection
{
    public interface ISettings
    {
        string WebStoreConnectionString { get; }
    }

    public class Settings : ISettings
    {
        private readonly IConfiguration _configuration;

        public Settings(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string WebStoreConnectionString => _configuration["WebStoreConnectionString"];
    }
}
