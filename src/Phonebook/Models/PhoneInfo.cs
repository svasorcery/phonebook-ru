using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Models
{
    public class PhoneInfo
    {
        public Phone Phone { get; set; }
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public int TimeZone { get; set; }
    }
}
