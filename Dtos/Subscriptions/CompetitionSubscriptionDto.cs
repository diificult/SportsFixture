namespace SportsFixture.Dtos.Subscriptions
{
    public class CompetitionSubscriptionDto
    {
        public int id { get; set; }
        public int TeamId { get; set; }
        public string CompetitionName { get; set; } = string.Empty;

    }
}
