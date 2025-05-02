namespace SportsFixture.Dtos.Subscriptions
{
    public class TeamSubscriptionDto
    {
        public int id { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; } = string.Empty;

    }
}
