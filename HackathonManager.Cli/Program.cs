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
            mentor.FirstName = Console.ReadLine();
            Console.WriteLine("Age(accepts integer):");
            mentor.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Description:");
            mentor.Description = Console.ReadLine();
            Console.WriteLine("PhoneNumber:");
            mentor.PhoneNumber = Console.ReadLine();
            mentor.IsAvailable = true;
            mentor.IsPresent = true;

            var db = Context.GetMLabsMongoDbRepo();
            //var db = Context.GetLocalMongoDbRepo();

            //Check to see if this person is already in the db
            //if (db.Single<DTO.Mentor>(x => x.Name == mentor.Name) != null)
            //{
            //    Console.WriteLine($"{mentor.Name} has already been registered.");
            //    Console.ReadKey();
            //    return;
            //}
            //if (db.Single<DTO.Mentor>(x => x.PhoneNumber == mentor.PhoneNumber) != null)
            //{
            //    Console.WriteLine($"{mentor.PhoneNumber} has already been registered.");
            //    Console.ReadKey();
            //    return;
            //}
            try
            {
                var registerMentor = new RegisterMentor(Context.GetMLabsMongoDbRepo(), Context.GetTwilioSmsService());
                registerMentor.Register(mentor);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }
        }
    }
}