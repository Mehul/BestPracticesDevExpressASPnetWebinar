using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DTOSample.Code.Data
{
	 public class WebsiteDBContext : DbContext
	 {
		  public WebsiteDBContext() : base("DefaultConnection") { }

		  public DbSet<Client> Clients { get; set; }
		  public DbSet<Country> Countries { get; set; }
		  public DbSet<Address> Addresses{ get; set; }
	 }
}