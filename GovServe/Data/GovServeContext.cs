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
        public DbSet<GovServe.Models.Department> Department { get; set; } = default!;

        public DbSet<GovServe.Models.Escalation> Escalation { get; set; } = default!;
        public DbSet<GovServe.Models.Case> Case { get; set; } = default!;

        public DbSet<GovServe.Models.Registration> Registration { get; set; } = default!;
        public DbSet<GovServe.Models.Login> Login { get; set; } = default!;
        public DbSet<GovServe.Models.Applications> Applications { get; set; } = default!;
        public DbSet<GovServe.Models.CitizenDocument> CitizenDocument { get; set; } = default!;

    }
}
