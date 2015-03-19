using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTOSample.Code.Data
{
	 public class Country
	 {
		  public Country() { }

		  public int ID { get; set; }
		  public string CountryName { get; set; }

		  public virtual ICollection<Client> Clients { get; set; }
	 }
}