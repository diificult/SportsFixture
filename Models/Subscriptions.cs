namespace SportsFixture.Models
{
    public class Subscriptions
    {
        public int Id { get; set; }
        public string UserId { get; set; }

    }
    public class TeamSubscription : Subscriptions
    {
        public int TeamId { get; set; }
        public SportTeam Team { get; set; }
    }

    public class CompetitionSubscription : Subscriptions
    {
        public int CompetitionId { get; set; }
        public SportCompetition Competition { get; set; }
    }

    public class FixtureSubscription : Subscriptions
    {
        public int FixtureId { get; set; }
        public SportFixture Fixture { get; set; }
    }
}
