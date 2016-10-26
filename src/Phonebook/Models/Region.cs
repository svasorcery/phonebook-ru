using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TimeZoneSpan { get; set; }
    }
}
