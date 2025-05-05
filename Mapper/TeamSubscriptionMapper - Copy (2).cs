using SportsFixture.Dtos.Subscriptions;
using SportsFixture.Models;

namespace SportsFixture.Mapper
{
    public static  class TeamSubscriptionMapper
    {
        public static TeamSubscriptionDto ToTeamSubscriptionDto (this TeamSubscription subModel)
        {
            return new TeamSubscriptionDto
            {
                id = subModel.Id,
                TeamId = subModel.TeamId,
                TeamName = subModel.Team?.Name,
            };
        }
    }
}
