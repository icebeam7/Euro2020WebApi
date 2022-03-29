using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Euro2020WebApi.Models
{
    public class EuroGroup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
