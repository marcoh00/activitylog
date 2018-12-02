using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace activitylog
{
    public class ActivityLogContext : DbContext
    {
        public DbSet<ActivityLog> ActivityLog { get; set; }
        public ActivityLogContext(DbContextOptions options) : base(options) {}
    }

    public class ActivityLog
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Hostname { get; set; }
        public string Color { get; set; }
        public string LocalIp { get; set; }
        public string RemoteIp { get; set; }
    }
}