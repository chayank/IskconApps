using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IskconKBCServer.Models
{
    public class DevoteeLanguageProficiency
    {
        public int Id { get; set; }
        public string Speak { get; set; }
        public string Read { get; set; }
        public string Write { get; set; }
        public string MotherTongue { get; set; }
        public string TranslatableFromEnglish { get; set; }
    }

}
