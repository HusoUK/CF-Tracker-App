using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFTracker.Models
{
    public class BodyMassIndexViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal WeightKg { get; set; }

        public string WeightTestingMachine { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal HeightCm { get; set; }

        public string HeightTestingMachine { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Bmi { get; set; }
    }
}
