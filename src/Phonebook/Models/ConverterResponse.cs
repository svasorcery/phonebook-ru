using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Models
{
    public class ConverterResponse
    {
        public string Input { get; set; }
        public PhoneInfo Result { get; set; }
        public Exception Error { get; set; }
        public string Status { get; set; }

        public string ErrorString => Error != null ? GetErrorString(Error) : null;
        private string GetErrorString(Exception error)
        {
            var message = $"{error.Message}";
            message += error.InnerException != null ? 
                $" => {GetErrorString(error.InnerException)}" : 
                null;
            return message;
        }
    }
}
