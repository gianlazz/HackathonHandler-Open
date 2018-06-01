﻿using HackathonManager.Models;
using HackathonManager.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonManager.SignalRRequestResponder
{
    public class Responder : IRequestResponder
    {
        public void MentorRequestResponse(MentorRequest mentorRequest)
        {
            if (mentorRequest.RequestAccepted == true && mentorRequest.DateTimeWhenProcessed != null)
            {
                //HackathonManager.WebMvc.Util.Functions.UpdateTeamOfMentorRequest(mentorRequest.Team, true);
            }
        }
    }
}
