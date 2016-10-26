using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Models
{
    public class Phone
    {
        public string CountryCode { get; set; }
        public string Prefix { get; set; }
        public string Number { get; set; }

        public string FullNumber => $"+{CountryCode}{Prefix}{Number}";
    }
}
