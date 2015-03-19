using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTOSample.Code.Data
{
	 public class Client
	 {
		  public Client() { }

		  public int Id { get; set; }
		  public string ClientName { get; set; }
		  public Country Country { get; set; }

		  public ICollection<Address> Addresses { get; set; }
	 }
}