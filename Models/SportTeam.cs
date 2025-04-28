using System.ComponentModel.DataAnnotations;

namespace SportsFixture.Models
{
    public class SportTeam
    {
        [Key]
        public int Id { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; } 

        public string Name { get; set; } = string.Empty;
        //Gets the ID referenced in the API
        public int APIid { get; set; }

    }
}
