using HackathonManager.DTO;
using HackathonManager.Models;
using HackathonManager.PocoModels;
using HackathonManager.WebMvc.Controllers;
using Microsoft.AspNet.SignalR;
using SignalRProgressBarSimpleExample.Hubs;

namespace HackathonManager.WebMvc.Util
{
    public class Functions
    {
        //hubContext.Clients.All.asdfasdf(message);
        //Not all
        //What's the difference between Users & Clients

        //Most likely should go by group?
        //Could go by group value passed in as a parameter from which would be
        //Set as their team id

        public static void SendProgress(string progressMessage, int progressCount, int totalItems)
        {
            //IN ORDER TO INVOKE SIGNALR FUNCTIONALITY DIRECTLY FROM SERVER SIDE WE MUST USE THIS
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();

            //CALCULATING PERCENTAGE BASED ON THE PARAMETERS SENT
            var percentage = (progressCount * 100) / totalItems;

            //PUSHING DATA TO ALL CLIENTS
            hubContext.Clients.All.AddProgress(progressMessage, percentage + "%");
        }

        public static void UpdateTeam(MentorRequest request, string message)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();

            if (request.RequestRejected)
            {
                hubContext.Clients.Group(request.Team.Name, new string[] { }).RequestUpdate(request, "Request Declined.");
            }
            if (request.RequestAccepted)
            {
                hubContext.Clients.Group(request.Team.Name, new string[] { }).RequestUpdate(request, "Mentor Accepted Request.");
            }
        }

        public static void AddTeam(Team team, string connectionId)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();
            hubContext.Groups.Add(connectionId, team.Name);
        }
    }
}