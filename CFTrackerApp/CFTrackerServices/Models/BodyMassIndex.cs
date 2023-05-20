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
    public class BodyMassIndex
    {
        public int Id { get; set; }

        [JsonIgnore]
        public UserInfo User { get; set; } = null!;

        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal WeightKg { get; set; }

        [MaxLength(50)]
        public string WeightTestingMachine { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal HeightCm { get; set; }

        [MaxLength(50)]
        public string HeightTestingMachine { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Bmi { get; set; }
    }
}
