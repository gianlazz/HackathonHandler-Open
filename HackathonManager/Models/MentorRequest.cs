using HackathonManager.DTO;
using HackathonManager.PocoModels;
using System;

namespace HackathonManager.Models
{
    public class MentorRequest
    {
        public Mentor Mentor { get; set; }
        public Team Team { get; set; }
        public bool RequestAccepted { get; internal set; }
        public DateTime DateTimeOfRequest { get; set; }
        public bool RequestHasBeenProcessed { get; set; }
        public DateTime DateTimeWhenProcessed { get; set; }

        public MentorRequest(Mentor mentor, Team team)
        {
            Mentor = mentor;
            Team = team;
        }
    }
}