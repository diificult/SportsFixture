using SportsFixture.Enums;

namespace SportsFixture.Models
{
    public class Sport
    {
        public int Id { get; set; }
        public SportType Type { get; set; }
        public string Name => Type.ToString();
    }
}
