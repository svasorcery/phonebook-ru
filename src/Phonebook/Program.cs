using Phonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var phonebook = new Services.PhonebookService();

            var phones = new List<string>
            {
                "7 895 6551 // номер-инвалид",
                "9965547892",
                "+7 (916) 987-65-43",
                "8-904-123-45-67",
                "(930) 1357901",
                "тел: 7(915)7002134 доб 112 (Мария)",
                "979 555 55 55 // номер валидный, но такого префикса нет",
                "8-997-8583465 // префикс есть, но не все номера заняты",
                "8902 201 1111 11 // существует, но регион - вся Россия (id=0)",
                "8119898988",
            };

            var result = phonebook.GetInfo(phones);
            Display(result);

            Console.ReadLine();
        }


        private static void Display(List<ConverterResponse> responseList)
        {
            Console.WriteLine("\n------------------------------------------------------------------------------");
            Console.WriteLine(" Согласно выписке из Российского плана нумерации по состоянию на 20.09.2016 г ");
            Console.WriteLine("------------------------------------------------------------------------------\n");

            foreach (var response in responseList)
            {
                Display(response);
                Console.WriteLine();
            }
        }
        private static void Display(ConverterResponse response)
        {
            if (response.Result != null && response.Error == null)
            {
                var successColor = ConsoleColor.Green;
                var timezone = response.Result.TimeZone < 0 ? 
                    $"МСК{response.Result.TimeZone}" : response.Result.TimeZone == 0 ?
                        "МСК" : $"МСК+{response.Result.TimeZone}";
                var info = response.Result != null ? $"{timezone}, {response.Result.Region.Name}, {response.Result.Operator.Name}" : "null";
                Console.WriteLine($"Вход:    {response.Input}");
                Console.WriteLine($"Статус:  {response.Status}");
                Console.Write($"Телефон: "); Colorize(response.Result.Phone.FullNumber, successColor);
                Console.Write($"Инфо:    "); Colorize(info, successColor);
            }
            else
            {
                var failColor = ConsoleColor.Red;
                var successColor = ConsoleColor.Green;
                var phone = response.Result != null ? response.Result.Phone.FullNumber : "null";
                Console.WriteLine($"Вход:    {response.Input}");
                Console.Write($"Статус:  "); Colorize(response.Status, failColor);
                Console.Write($"Телефон: "); Colorize(phone, response.Result != null ? successColor : failColor);
                Console.Write($"Инфо:    "); Colorize(response.ErrorString, failColor);
            }
        }
        private static void Colorize(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
