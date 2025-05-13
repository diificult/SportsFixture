using Newtonsoft.Json;
using SportsFixture.Dtos.Team;
using SportsFixture.Interfaces;
using SportsFixture.Mapper;
using SportsFixture.Models;

namespace SportsFixture.Services.Api
{
    public class apiFootballService : IapiSportService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public apiFootballService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _config = configuration;
        }
        public async Task<List<SportTeam>> getTeamByName(string name)
        {
            try
            {

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/teams?name={name}"),
                    Headers =
                {
                    { "x-rapidapi-key", "cbf5bd73c3msh6ee26877a08bd1dp15274djsn313e1437ca3c" },
                     { "x-rapidapi-host", "api-football-v1.p.rapidapi.com" },
                },
                };
                var response = await _httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    var tasks = JsonConvert.DeserializeObject<ApiFootballTeam>(body);
                    if (tasks != null)
                    {
                        return tasks.response.Select(t => t.ToSportTeamFromapiFootball()).ToList();
                    }
                    return null;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return null;

        }
    }
}
 