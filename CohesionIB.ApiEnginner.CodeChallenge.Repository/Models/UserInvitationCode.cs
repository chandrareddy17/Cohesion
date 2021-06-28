using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CohesionIB.ApiEnginner.CodeChallenge.Repository.Models
{
    public class UserInvitationCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ID { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("DeviceId")]
        public long? DeviceId { get; set; }
        public ulong InvitationCode { get; set; }
        public virtual Device Device { get; set; }
    }
}
