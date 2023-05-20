using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFTracker.Models
{
    public class LungFunctionViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Fev { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Fvc1 { get; set; }

        public string TestingMachine { get; set; }
    }
}
