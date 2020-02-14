using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IskconKBCServer.Common.Enums
{
    public enum ShikshaLevel
    {
        Shraddavan,
        [Display(Name = "Krishna Sevaka")]
        KrishnaSevaka,
        [Display(Name = "Krishna Sadhaka")]
        KrishnaSadhaka,
        [Display(Name = "Krishna Upasaka")]
        KrishnaUpasaka,
        [Display(Name = "Prabhupada Ashraya")]
        PrabhupadaAshraya,
        [Display(Name = "Guru Ashraya")]
        GuruAshraya,
        [Display(Name = "First Initiation")]
        FirstInitiation,
        [Display(Name = "Second Initiation")]
        SecondInitiation
    }
}
