using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GovServe.Models;

namespace GovServe.Data
{
    public class GovServeContext : DbContext
    {
        public GovServeContext (DbContextOptions<GovServeContext> options)
            : base(options)
        {
        }

        public DbSet<GovServe.Models.Notification> Notification { get; set; } = default!;
    }
}
