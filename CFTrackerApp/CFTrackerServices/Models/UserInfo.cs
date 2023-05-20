using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFTrackerServices.Models
{
    public class UserInfo
    {
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        [MaxLength(15)]
        [Column(TypeName = "varchar(15)")]
        public string PhoneNumber { get; set; }

        [MaxLength(200)]
        public string EmailAddress { get; set; }

        [ForeignKey("UserInfoId")]
        public ICollection<LungFunction>? LungFunctions { get; set; }

        [ForeignKey("UserInfoId")]
        public ICollection<BodyMassIndex>? BodyMassIndexes { get; set; }
    }
}
