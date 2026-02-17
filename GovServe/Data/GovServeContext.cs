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
		public GovServeContext(DbContextOptions<GovServeContext> options)
			: base(options)
		{
		}

		

		
	
	    public DbSet<GovServe.Models.User> User { get; set; } = default!;
	    public DbSet<GovServe.Models.Login> Login { get; set; } = default!;
	    public DbSet<GovServe.Models.Applications> Applications { get; set; } = default!;
	    public DbSet<GovServe.Models.CitizenDocument> CitizenDocument { get; set; } = default!;

		

	}
}