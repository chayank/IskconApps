﻿using IskconKBCServer.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IskconKBCServer.Models
{
    public class DevoteeLanguageProficiency
    {
        public int Id { get; set; }
        public int DevoteeId { get; set; }
        public string Speak { get; set; }
        public string Read { get; set; }
        public string Write { get; set; }
        public Language MotherTongue { get; set; }
        public string TranslatableFromEnglish { get; set; }

        public Devotee Devotee { get; set; }
    }

}
