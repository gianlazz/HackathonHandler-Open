using HackathonManager.Models;
using HackathonManager.Sms;
using HackathonManager.WebMvc.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonManager.WebMvc.Util
{
    public class Responder : IRequestResponder
    {
        public void MentorRequestResponse(MentorRequest mentorRequest)
        {
            if (mentorRequest.RequestAccepted == true && mentorRequest.DateTimeWhenProcessed != null)
            {
                var message = $"{mentorRequest.Mentor.FirstName} accepted your request!";
                Functions.UpdateTeamOfMentorRequest(mentorRequest.Team, true, message);
            }
            if (mentorRequest.RequestAccepted == false && mentorRequest.DateTimeWhenProcessed != null)
            {
                var message = $"{mentorRequest.Mentor.FirstName} is not available right now";
                Functions.UpdateTeamOfMentorRequest(mentorRequest.Team, true, message);
            }
        }
    }
}
