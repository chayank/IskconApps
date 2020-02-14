using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IskconKBCServer.Common
{
    public enum BvResponsibility
    {
        [Display(Name = "Intern Leader")]
        InternLeader,
        [Display(Name = "Bv Servant Leader")]
        BvServantLeader,
        [Display(Name = "Sector Leader")]
        SectorLeader,
        [Display(Name = "Circle Leader")]
        CircleLeader,
        None
    }
}
