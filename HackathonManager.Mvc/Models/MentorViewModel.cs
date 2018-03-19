using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HackathonManager.Persistance;

namespace HackathonManager.Mvc.Models
{
    public class MentorViewModel
    {
        public List<Mentor> Mentors { get; set; }
        public List<Mentor> PresentMentors { get; set; }
        public List<Mentor> AvailableMentors { get; set; }
    }
}