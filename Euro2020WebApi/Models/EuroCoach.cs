using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Euro2020WebApi.Models
{
    public class EuroCoach
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }

        [ForeignKey("FK_Country")]
        public int EuroCountryId { get; set; }
        public EuroCountry FK_Country { get; set; }
    }
}
