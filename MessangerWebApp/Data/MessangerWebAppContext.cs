using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MessangerWebApp.Models;

namespace MessangerWebApp.Data
{
    public class MessangerWebAppContext : DbContext
    {
        public MessangerWebAppContext (DbContextOptions<MessangerWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<MessangerWebApp.Models.Message> Message { get; set; }
    }
}
