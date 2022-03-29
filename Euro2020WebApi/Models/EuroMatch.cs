using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Euro2020WebApi.Models
{
    public class EuroMatch
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }

        [ForeignKey("FK_Group")]
        public int EuroGroupId { get; set; }
        public EuroGroup FK_Group { get; set; }

        [ForeignKey("FK_HomeTeam")]
        public int EuroHomeTeamId { get; set; }
        public EuroTeam FK_HomeTeam { get; set; }

        [ForeignKey("FK_AwayTeam")]
        public int EuroAwayTeamId { get; set; }
        public EuroTeam FK_AwayTeam { get; set; }

        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }

        [ForeignKey("FK_Referee")]
        public int EuroRefereeId { get; set; }
        public EuroReferee FK_Referee { get; set; }

        public DateTime ScheduledDateTime { get; set; }

        [ForeignKey("FK_Stadium")]
        public int EuroStadiumId { get; set; }
        public EuroStadium FK_Stadium { get; set; }
    }
}
