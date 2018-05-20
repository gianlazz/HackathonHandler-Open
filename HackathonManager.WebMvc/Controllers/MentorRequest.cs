using HackathonManager.DTO;
using HackathonManager.PocoModels;

namespace HackathonManager.WebMvc.Controllers
{
    public class MentorRequest
    {
        public Mentor mentor;
        public Team team;

        public MentorRequest(Mentor mentor, Team team)
        {
            this.mentor = mentor;
            this.team = team;
        }
    }
}