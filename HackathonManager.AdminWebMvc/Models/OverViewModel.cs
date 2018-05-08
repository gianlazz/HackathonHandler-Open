using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HackathonManager.DTO;
using HackathonManager.PocoModels;

namespace HackathonManager.AdminWebMvc.Models
{
    public class OverViewModel
    {
        public List<Mentor> Mentors { get; set; }
        public List<Judge> Judges { get; set; }
        public List<Team> Teams { get; set; }
    }
}