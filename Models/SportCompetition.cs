using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsFixture.Models
{
    [Table("Events")]
    public class SportCompetition
    {
        [Key]
        public int SportEventID { get; set; }

        public string SportEventName { get; set; } = string.Empty;
        public List<SportFixture> AllFixtures { get; set; } = new List<SportFixture>();
    }
}
