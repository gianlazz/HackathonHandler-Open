using HackathonManager.DTO;
using HackathonManager.PocoModels;

namespace HackathonManager.Models
{
    public class MentorRequest
    {
        public Mentor Mentor { get; set; }
        public Team Team { get; set; }
        public bool RequestRejected { get; set; }
        public bool RequestAccepted { get; internal set; }

        public MentorRequest(Mentor mentor, Team team)
        {
            Mentor = mentor;
            Team = team;
        }
    }
}