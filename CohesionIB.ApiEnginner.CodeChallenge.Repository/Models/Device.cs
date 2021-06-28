using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CohesionIB.ApiEnginner.CodeChallenge.Repository.Models
{
   public class Device
    {
               
        [Required]
        [Key]
        public long DeviceID { get; set; }
        [Required]
        [StringLength(50)]
        public string DeviceName { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
