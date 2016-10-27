using Phonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Services
{
    public class PhonebookService
    {
        private readonly Stores.DefCodeStore _defCodeStore;
        private readonly Stores.OperatorStore _operatorStore;
        private readonly Stores.RegionStore _regionStore;

        private readonly List<char> _registeredCountryCodeChars;
        private readonly List<char> _registeredPrefixFirstChars;

        private const int _maxPhoneLength = 11;

        public PhonebookService()
        {
            _defCodeStore = new Stores.DefCodeStore();
            _operatorStore = new Stores.OperatorStore();
            _regionStore = new Stores.RegionStore();

            _registeredCountryCodeChars = new List<char> { '7', '8' };
            _registeredPrefixFirstChars = new List<char> { '3', '4', '8', '9' };
        }

        public ConverterResponse Convert(string input)
        {
            var phoneBuilder = new StringBuilder(_maxPhoneLength);
            foreach (var s in input)
            {
                if (phoneBuilder.Length == _maxPhoneLength) { break; }
                if (char.IsDigit(s))
                {
                    phoneBuilder.Append(s);
                }
                //else if (char.IsLetter(s)) { break; }
            }

            var phoneString = phoneBuilder.ToString();
            if (!String.IsNullOrEmpty(phoneString))
            {
                if (phoneString.Length >= _maxPhoneLength && _registeredCountryCodeChars.Contains(phoneString.First()))
                {
                    phoneString = phoneString.Substring(1, 10);
                }
                if (!_registeredPrefixFirstChars.Contains(phoneString.First()))
                {
                    phoneString = null;
                }
            }
            return GetConvertResponse(input, phoneString);
        }

        public List<ConverterResponse> Convert(List<string> phones)
        {
            var result = new List<ConverterResponse>();
            foreach (var input in phones)
            {
                result.Add(Convert(input));
            }
            return result;
        }

        public ConverterResponse GetInfo(string input)
        {
            var response = Convert(input);
            if (response.Error != null)
            {
                return response;
            }
            return GetInfo(response.Result.Phone, input);
        }

        public ConverterResponse GetInfo(Phone phone)
        {
            //return GetInfo(phone, null);
            return GetInfo(phone, phone.FullNumber);
        }

        public ConverterResponse GetInfo(Phone phone, string input)
        {
            DefCode defCodeInfo;
            try
            {
                defCodeInfo = _defCodeStore.Find(phone.Prefix, phone.Number);
            }
            catch (Exception e)
            {
                return GetPhoneInfoResponse(phone, null, null, e, input);
            }

            Operator @operator;
            try
            {
                @operator = _operatorStore.Find(defCodeInfo.OperatorId);
            }
            catch (Exception e)
            {
                return GetPhoneInfoResponse(phone, null, null, e, input);
            }

            Region region;
            try
            {
                region = _regionStore.Find(defCodeInfo.RegionId);
            }
            catch (Exception e)
            {
                return GetPhoneInfoResponse(phone, @operator, null, e, input);
            }

            return GetPhoneInfoResponse(phone, @operator, region, null, input);
        }

        public List<ConverterResponse> GetInfo(List<string> phones)
        {
            var result = new List<ConverterResponse>();
            foreach (var input in phones)
            {
                result.Add(GetInfo(input));
            }
            return result;
        }

        public List<ConverterResponse> GetInfo(List<Phone> phones)
        {
            var result = new List<ConverterResponse>();
            foreach (var input in phones)
            {
                result.Add(GetInfo(input));
            }
            return result;
        }


        private ConverterResponse GetConvertResponse(string input, string phone)
        {
            if (phone == null)
            {
                return new ConverterResponse
                {
                    Input = input,
                    Result = null,
                    Error = new FormatException($"Телефон \"{input}\" имеет недопустимый формат"),
                    Status = GetStatus(Status.Error)
                };
            }
            //else
            return phone.Length == _maxPhoneLength - 1 ?
                new ConverterResponse
                {
                    Input = input,
                    Result = new PhoneInfo
                    {
                        Phone = new Phone
                        {
                            CountryCode = "7",
                            Prefix = phone.Substring(0, 3),
                            Number = phone.Substring(3, 7),
                        },
                    },
                    Status = GetStatus(Status.Valid),
                } :
                new ConverterResponse
                {
                    Input = input,
                    Result = null,
                    Error = new ArgumentException("Недопустимая длина телефонной строки"),
                    Status = GetStatus(Status.Error),
                };
        }

        private ConverterResponse GetPhoneInfoResponse(Phone phone, Operator @operator, Region region, Exception error, string input)
        {
            var response = new ConverterResponse();
            response.Input = input;
            response.Result = new PhoneInfo();
            response.Result.Phone = phone;
            
            if (@operator == null)
            {
                response.Status = GetStatus(Status.Error);
                response.Error = new FormatException("Оператор не найден", error);
                return response;
            }

            response.Result.OperatorId = @operator.Id;
            response.Result.Operator = @operator;

            if (region == null)
            {
                response.Status = GetStatus(Status.Error);
                response.Error = new FormatException("Регион не найден", error);
                return response;
            }

            response.Result.RegionId = region.Id;
            response.Result.Region = region;
            response.Result.TimeZone = region.TimeZoneSpan;

            if (error != null)
            {
                response.Status = GetStatus(Status.Error);
                response.Error = error;
                return response;
            }

            response.Status = GetStatus(Status.Complete);
            return response;
        }

        private string GetStatus(Status status)
        {
            switch (status)
            {
                case Status.Error: return "Error";
                case Status.Valid: return "Valid";
                case Status.Complete: return "Complete";
                default: return "Unknown";
            }
        }
    }
}
