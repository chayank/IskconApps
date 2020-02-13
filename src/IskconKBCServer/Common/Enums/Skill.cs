using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IskconKBCServer.Common.Enums
{
    public enum Skill
    {
        Singing,
        Kartal,
        Mridangam,
        Harmonium,
        Kitchen,
        Stitching,
        [Display(Name = "Deity Dressing")]
        DeityDressing,
        [Display(Name = "Guest Care")]
        GuestCare,
        Gardening,
        [Display(Name = "Sound System Managment")]
        SoundSystem,
        [Display(Name = "Pick/Drop Visiting Guest")]
        PickOrDropVisitingGuest,
        [Display(Name = "Social Media")]
        SocialMedia,
        [Display(Name = "Book Distribution")]
        BookDistribution,
        [Display(Name = "Graphics Design")]
        GraphicsDesign,
        [Display(Name = "Accounting Services")]
        AccountingServices,
        Translation,
        [Display(Name = "Children Program")]
        ChildrenProgram,
        [Display(Name = "Fund Raising")]
        FundRaising
    }
}
