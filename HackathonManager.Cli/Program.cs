using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackathonManager.Sms;

namespace HackathonManager.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TwilioSmsService.SendSms(4255899296, Console.ReadLine()));
            Console.ReadKey();
        }
    }
}
