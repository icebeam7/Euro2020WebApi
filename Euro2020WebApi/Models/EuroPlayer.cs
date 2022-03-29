using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Euro2020WebApi.Models
{
    public class EuroPlayer
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }

        [ForeignKey("FK_Team")]
        public int EuroTeamId { get; set; }
        public EuroTeam FK_Team { get; set; }
        
        public int Goals { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int OwnGoals { get; set; }

        [ForeignKey("FK_Position")]
        public int EuroPositionId { get; set; }
        public EuroPosition FK_Position { get; set; }
    }
}
