using IskconKBCServer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IskconKBCServer.Models
{
    public class DevoteeDetail
    {
        public int Id { get; set; }
        public int DevoteeId { get; set; }
        public string InitiatedName { get; set; }
        [Required]
        public Gender Sex { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        [Required]
        public string Address { get; set; }
        public string Profession { get; set; }
        [Required]
        public string MobileNo { get; set; }
        public string WhatsappMobileNo { get; set; }
        [Required]
        public string EmergencyContactName { get; set; }
        [Required]
        public string EmergencyContactMobileNo { get; set; }

        public Devotee Devotee { get; set; }
    }
}
