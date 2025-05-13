using SportsFixture.Enums;
using SportsFixture.Interfaces;
using SportsFixture.Services.Api;

namespace SportsFixture.Services
{
    public class SportServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SportServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IapiSportService GetTeamService(SportType sport)
        {
            return sport switch
            {
                SportType.Football => _serviceProvider.GetRequiredService<IapiSportService>() ?? throw new InvalidOperationException("Service not registered"),
                _ => throw new ArgumentException("Sport Not Found")
            };
        }
    }
}
