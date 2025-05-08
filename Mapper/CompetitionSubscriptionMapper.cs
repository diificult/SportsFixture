using SportsFixture.Dtos.Subscriptions;
using SportsFixture.Models;

namespace SportsFixture.Mapper
{
    public static  class CompetitionSubscriptionMapper
    {
        public static CompetitionSubscriptionDto ToTeamSubscriptionDto (this CompetitionSubscription subModel)
        {
            return new CompetitionSubscriptionDto
            {
                id = subModel.Id,
                 CompetitionName = subModel.Competition?.SportEventName,
            };
        }
    }
}
