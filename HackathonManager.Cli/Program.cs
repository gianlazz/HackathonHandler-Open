using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackathonManager.DIContext;

namespace HackathonManager.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Add new mentors to the system:");
            var mentor = new DTO.Mentor();
            Console.WriteLine("Name:");
            mentor.Name = Console.ReadLine();
            Console.WriteLine("Age(accepts integer):");
            mentor.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Description:");
            mentor.Description = Console.ReadLine();
            Console.WriteLine("PhoneNumber:");
            mentor.PhoneNumber = Console.ReadLine();
            mentor.IsAvailable = true;
            mentor.IsPresent = true;

            //var db = Context.GetMLabsMongoDbRepo();
            var db = Context.GetLocalMongoDbRepo();

            //Check to see if this person is already in the db
            if (db.Single<DTO.Mentor>(x => x.Name == mentor.Name) != null)
            {
                Console.WriteLine($"{mentor.Name} has already been registered.");
                Console.ReadKey();
                return;
            }
            if (db.Single<DTO.Mentor>(x => x.PhoneNumber == mentor.PhoneNumber) != null)
            {
                Console.WriteLine($"{mentor.PhoneNumber} has already been registered.");
                Console.ReadKey();
                return;
            }
            try
            {
                db.Add(mentor);
                var mentorFromDb = db.Single<DTO.Mentor>(x => x.Name == mentor.Name);

            var mentorFromDb = db.Single<DTO.Mentor>(x => x.PhoneNumber == mentor.PhoneNumber);

            var smsService = Context.GetTwilioSmsService();
            Console.WriteLine(smsService.SendSms(uint.Parse(mentorFromDb.PhoneNumber),
            $"🔥 {mentorFromDb.Name}, you've been added in and registered as a mentor for this event. 🔥" +

            $"\n\nYou'll recieve prompts via sms from here out for your instructions. " +
            $"After finishing a mentoring task it will be your responsability to" +
            $"message this number again saying FINISHED. That way you'll be able to signify availability again." +

            $"\n\nIf you don't set yourself as FINISHED within the first 20 min you will" +
            $"be prompted to see if you're done every 15 minutes there out until you are."));

                Console.WriteLine($"Introductory sms sent to {mentor.Name} at {mentor.PhoneNumber}.");
                Console.ReadKey();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }
        }
    }
}