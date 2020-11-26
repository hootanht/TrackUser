using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackUser.Models;

namespace TrackUser.Hubs
{
    public class TrackUserHub : Hub
    {
        public static List<User> Users = new List<User>();
        public async override Task OnConnectedAsync()
        {
            var httpcontext = Context.GetHttpContext();
            var pathVisit = httpcontext.Request.Query["pagename"];
            var ip = httpcontext.Connection.RemoteIpAddress.ToString();
            if (Users.Any(u => u.IP == ip))
            {
                Users.Find(u => u.IP == ip).Online = true;
                Users.Find(u => u.IP == ip).PathVisit = pathVisit;
            }
            else
            {
                Users.Add(new User
                {
                    UserName = "Guest",
                    IP = ip,
                    Online = true,
                    PathVisit = pathVisit,
                    StartAt = DateTime.Now
                });
            }
            await base.OnConnectedAsync();
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            var httpcontext = Context.GetHttpContext();
            var pathVisit = httpcontext.Request.Query["pagename"];
            var ip = httpcontext.Connection.RemoteIpAddress.ToString();
            Users.Find(u => u.IP == ip).Online = false;
            await base.OnDisconnectedAsync(exception);
        }
    }
}
