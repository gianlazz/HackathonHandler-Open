﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackathonManager.DTO;
using HackathonManager.RepositoryPattern;
using HackathonManager.Interfaces;

namespace HackathonManager
{
    public class RegisterMentor
    {
        private IRepository _Repository;
        private ISmsService _SmsService;

        public RegisterMentor(IRepository repository, ISmsService smsService)
        {
            _Repository = repository;
            _SmsService = smsService;
        }

        public void Register(Mentor mentor)
        {
            _Repository.Add(mentor);

            var mentorFromDb = _Repository.Single<DTO.Mentor>(x => x.Name == mentor.Name);

            _SmsService.SendSms(uint.Parse(mentorFromDb.PhoneNumber),
            $"🔥 {mentorFromDb.Name}, you've been added in and registered as a mentor for this event. 🔥" +

            $"\n\nYou'll recieve prompts via sms from here out for your instructions. " +
            $"After finishing a mentoring task it will be your responsability to" +
            $"message this number again saying FINISHED. That way you'll be able to signify availability again." +

            $"\n\nIf you don't set yourself as FINISHED within the first 20 min you will" +
            $"be prompted to see if you're done every 5 minutes there out until you are.");

            Console.WriteLine($"Introductory sms sent to {mentor.Name} at {mentor.PhoneNumber}.");
            Console.ReadKey();
        }
    }
}