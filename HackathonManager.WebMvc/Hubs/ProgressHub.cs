using Microsoft.AspNet.SignalR;

namespace SignalRProgressBarSimpleExample.Hubs
{
    public class ProgressHub : Hub
    {
        private void test()
        {
            string asdf = Context.ConnectionId;
        }
    }
}