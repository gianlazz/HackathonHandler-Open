using HackathonManager.DTO;
using HackathonManager.PocoModels;
using System;

namespace HackathonManager.Models
{
    public class MentorRequest
    {
        public DateTime DateTimeOfRequest { get; set; }
        public Mentor Mentor { get; set; }
        public Team Team { get; set; }
        public bool RequestAccepted { get; internal set; }
        public bool RequestHasBeenProcessed { get; set; }
        public DateTime DateTimeWhenProcessed { get; set; }

        public MentorRequest()
        {
            DateTimeOfRequest = DateTime.Now;
        }
    }
}