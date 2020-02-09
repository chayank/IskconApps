using IskconKBCServer.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IskconKBCServer.Models
{
    public class Devotee
    {
        public int DevoteeId { get; set; }
        public string UserId { get; set; }
        public Relation RelationshipWithUser { get; set; }
        public IdentityUser User { get; set; }
    }
}