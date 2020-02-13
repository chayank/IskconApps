using IskconKBCServer.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IskconKBCServer.Models
{
    public class DevoteeSkill
    {
        public int Id { get; set; }
        public int DevoteeId { get; set; }
        public string Learning { get; set; }
        public string Teaching { get; set; }
        public string UsingInYatra { get; set; }
        public string HaveTheSkills { get; set; }
        public string SpecialSkills { get; set; }

        public Devotee Devotee { get; set; }
    }
}
