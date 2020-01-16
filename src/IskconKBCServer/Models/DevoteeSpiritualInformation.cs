using IskconKBCServer.Common;
using IskconKBCServer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IskconKBCServer.Models
{
    public class DevoteeSpiritualInformation
    {
        public int Id { get; set; }
        public bool IsAssociatedToBv { get; set; }
        public BvResponsibility ResponsibiltyType { get; set; }
        public string Attending { get; set; }
        public string Teaching { get; set; }
        public string ShikshaLevel { get; set; }
        public string ShikshaLevelReceivedDates { get; set; }
    }
}
