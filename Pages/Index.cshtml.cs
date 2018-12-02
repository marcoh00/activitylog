using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace activitylog.Pages
{
    public class IndexModel : PageModel
    {
        public IInstanceSettings Settings { get; }
        public ActivityLogContext Context { get; }
        
        public List<ActivityLog> LogEntries { get; set; }

        public IndexModel(IInstanceSettings settings, ActivityLogContext context)
        {
            Settings = settings;
            Context = context;
        }
        
        public async Task OnGetAsync()
        {
            await Context.ActivityLog.AddAsync(new ActivityLog
            {
                Hostname = System.Net.Dns.GetHostName(),
                Color = Settings.Color,
                LocalIp = HttpContext.Connection.LocalIpAddress.ToString(),
                RemoteIp = HttpContext.Connection.RemoteIpAddress.ToString(),
                Timestamp = DateTime.Now
            });
            await Context.SaveChangesAsync();

            LogEntries = await Context.ActivityLog.OrderByDescending(log => log.Id).Take(100).ToListAsync();
        }
    }
}
