using IskconKBCServer.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IskconKBCServer.Models
{
    public class DevoteeDetails
    {
        public int Id { get; set; }
        public string DevoteeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string InitiatedName { get; set; }
        public Gender Sex { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public string Profession { get; set; }
        public string MobileNo { get; set; }
        public string WhatsappMobileNo { get; set; }
        public int EmergencyContactName { get; set; }
        public int EmergencyContactMobileNo { get; set; }

        public IdentityUser Devotee { get; set; }

    }
}
