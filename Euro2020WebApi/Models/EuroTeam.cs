using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Euro2020WebApi.Models
{
    public class EuroTeam
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("FK_Country")]
        public int EuroCountryId { get; set; }
        public EuroCountry FK_Country { get; set; }

        public int GroupPosition { get; set; }
        public int Games { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        public int Points { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }

        [ForeignKey("FK_Group")]
        public int EuroGroupId { get; set; }
        public EuroGroup FK_Group { get; set; }

        [ForeignKey("FK_Coach")]
        public int EuroCoachId { get; set; }
        public EuroCoach FK_Coach { get; set; }
    }
}
