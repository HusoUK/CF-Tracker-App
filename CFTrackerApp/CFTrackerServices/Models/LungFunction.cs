using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CFTrackerServices.Models
{
    public class LungFunction
    {
        public int Id { get; set; }

        [JsonIgnore]
        public UserInfo User { get; set; } = null!;

        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Fev { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Fvc1 { get; set; }

        [MaxLength(50)]
        public string TestingMachine { get; set; }
    }
}
