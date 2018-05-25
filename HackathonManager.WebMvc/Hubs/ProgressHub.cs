using HackathonManager.Models;
using HackathonManager.PocoModels;
using Microsoft.AspNet.SignalR;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Web;

namespace SignalRProgressBarSimpleExample.Hubs
{
    public class ProgressHub : Hub
    {
        public void UpdateTeam(MentorRequest request, string message)
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

        public Task<string> GetConnectionId()
        {
            return Task.Run(() =>
            {
                return Context.ConnectionId;
            });
        }

        public void AddConnectionToTeamGroup()
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();

            Cookie cookie = Context.Request.Cookies["team"];
            //HttpCookie cookie = HttpContext.Request.Cookies.Get("team");
            //HttpCookie cookie = HttpContext.Current.Request.Cookies["team"];
            if (cookie != null)
            {
                hubContext.Groups.Add(Context.ConnectionId, cookie.Value);
            }

        }

        public void MessageTeam(Team team, string message)
        {
            Clients.Group(team.Name, new string[] { }).message(message);
        }

        //https://docs.microsoft.com/en-us/aspnet/signalr/overview/guide-to-the-api/working-with-groups
        //public Task JoinRoom(string roomName)
        //{
        //    return Groups.Add(Context.ConnectionId, roomName);
        //}

        //public Task LeaveRoom(string roomName)
        //{
        //    return Groups.Remove(Context.ConnectionId, roomName);
        //}

        public static ConcurrentDictionary<string, Team> MyUsers = new ConcurrentDictionary<string, Team>();

        public override Task OnConnected()
        {
            Cookie cookie = Context.Request.Cookies["team"];
            if (cookie != null)
            {
                MyUsers.TryAdd(Context.ConnectionId, new Team() { Name = cookie.Value });
                //string name = Context.User.Identity.Name;

                //Groups.Add(Context.ConnectionId, name);
                Groups.Add(Context.ConnectionId, cookie.Name);
            }

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Team team;
            MyUsers.TryRemove(Context.ConnectionId, out team);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
    }
}