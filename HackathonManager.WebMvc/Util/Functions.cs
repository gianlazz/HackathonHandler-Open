using HackathonManager.DTO;
using HackathonManager.Models;
using HackathonManager.PocoModels;
using HackathonManager.WebMvc.Controllers;
using Microsoft.AspNet.SignalR;
using SignalRProgressBarSimpleExample.Hubs;
using System.Collections.Generic;
using System.Web;

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

        public static void SendProgressTeamA(string progressMessage, int progressCount, int totalItems)
        {
            //IN ORDER TO INVOKE SIGNALR FUNCTIONALITY DIRECTLY FROM SERVER SIDE WE MUST USE THIS
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();

            //CALCULATING PERCENTAGE BASED ON THE PARAMETERS SENT
            var percentage = (progressCount * 100) / totalItems;

            //PUSHING DATA TO ALL CLIENTS
            hubContext.Clients.Group("ExampleTeam").AddProgress(progressMessage, percentage + "%");
        }

        public static void SendProgressTeamB(string progressMessage, int progressCount, int totalItems)
        {
            //IN ORDER TO INVOKE SIGNALR FUNCTIONALITY DIRECTLY FROM SERVER SIDE WE MUST USE THIS
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();

            //CALCULATING PERCENTAGE BASED ON THE PARAMETERS SENT
            var percentage = (progressCount * 100) / totalItems;

            //PUSHING DATA TO ALL CLIENTS

            //foreach (KeyValuePair<string, Team> entry in ProgressHub.MyUsers)
            //{
            //    // do something with entry.Value or entry.Key
            //    if (entry.Value == new Team() { Name = "ExampleTeamB" })
            //    {
            //        hubContext.Clients.Client(entry.Key).AddProgress(progressMessage, percentage + "%");
            //    }
            //}

            hubContext.Clients.Group("ExampleTeamB").AddProgress(progressMessage, percentage + "%");
            //hubContext.Clients.Group("team").AddProgress(progressMessage, percentage + "%");
        }
    }
}