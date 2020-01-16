using IskconKBCServer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IskconKBCServer.Models
{
    public class Devotee
    {
        public int UserId { get; set; }
        public int DevoteeId { get; set; }
        public Relation RelationshipWithUser { get; set; }
    }
}
