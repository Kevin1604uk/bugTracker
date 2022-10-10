using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BugTracker.Models;

namespace BugTracker.Data
{
    public class BugTrackerContext : DbContext
    {
        public BugTrackerContext (DbContextOptions<BugTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<BugTracker.Models.bugtracker> bugtracker { get; set; }

        public DbSet<BugTracker.Models.User> User { get; set; }
    }
}
