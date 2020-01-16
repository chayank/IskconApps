using IskconKBCServer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IskconKBCServer.Models
{
    public class DevoteeSkills
    {
        public int Id { get; set; }
        public Devotee DevoteeId { get; set; }
        public string Learning { get; set; }
        public string Teaching { get; set; }
        public string UsingInYatra { get; set; }
        public string HaveTheSkills { get; set; }

    }
}
