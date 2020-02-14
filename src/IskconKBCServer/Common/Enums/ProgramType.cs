using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IskconKBCServer.Common
{
    public enum ProgramType
    {
        Children,
        Ladies,
        Youth,
        Outreach,
        Home,
        [Display(Name = "Bhagavat-Gita")]
        BhagavatGita,
        [Display(Name = "Srimad Bhagavatam")]
        SrimadBhagavatam,
        [Display(Name = "Caitanya-Caritamrta")]
        CaitanyaCaritamrta,
        [Display(Name = "Bhakti-Sastri")]
        BhaktiSastri,
        Other
    }
}
