using IskconKBCServer.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IskconKBCServer.Models
{
    public class DevoteeRelationships
    {
        public int Id { get; set; }
        public string DevoteeId { get; set; }
        public Relation RelationshipWithUser { get; set; }
        public string RelatedDevoteeId { get; set; }
        public IdentityUser Devotee { get; set; }
        public IdentityUser RelatedDevotee { get; set; }
    }
}
