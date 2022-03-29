using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Euro2020WebApi.Models
{
    public class EuroStadium
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }

        [ForeignKey("FK_City")]
        public int EuroCityId { get; set; }
        public EuroCity FK_City { get; set; }

        public int Capacity { get; set; }
    }
}
