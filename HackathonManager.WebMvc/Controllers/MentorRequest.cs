using HackathonManager.DTO;
using HackathonManager.PocoModels;

namespace HackathonManager.WebMvc.Controllers
{
    public class MentorRequest
    {
        public Mentor Mentor { get; set; }
        public Team Team { get; set; }

        public MentorRequest(Mentor mentor, Team team)
        {
            Mentor = mentor;
            Team = team;
        }
    }
}