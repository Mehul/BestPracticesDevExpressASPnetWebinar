using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTOSample.Code.Data
{
	 public class Address
	 {
		  public Address() { }
		  public int Id { get; set; }
		  public string Street { get; set; }
		  public string ZipCode { get; set; }
		  public string City { get; set; }
		  public string State { get; set;  }

		  public Client Client { get; set; }

	 }
}