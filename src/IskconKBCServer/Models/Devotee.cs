using IskconKBCServer.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IskconKBCServer.Models
{
    public class Devotee
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        public Relation RelationshipWithUser { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public IdentityUser User { get; set; }

    }
}