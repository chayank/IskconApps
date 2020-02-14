using IskconKBCServer.Common;
using IskconKBCServer.Common.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IskconKBCServer.Models
{
    public class DevoteeSpiritualInformation
    {
        public int Id { get; set; }
        public int DevoteeId { get; set; }
        public string CareGiverDevoteeName { get; set; }
        public Decision IsAssociatedToBv { get; set; }
        public  string BvName{ get; set; }
        public string SectorName { get; set; }
        public string CircleName { get; set; }
        public BvResponsibility ResponsibiltyType { get; set; }
        public string Attending { get; set; }
        public string Teaching { get; set; }
        public string ShikshaLevel { get; set; }
        public Devotee Devotee { get; set; }
    }
}
