using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebServices.Hubs
{
    public class SıgnalRHub : Hub
    {
        Context context = new Context();

        public async Task SendCategoryCount()
        {
            var value = context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoriCount",value);
        }
    }
}
