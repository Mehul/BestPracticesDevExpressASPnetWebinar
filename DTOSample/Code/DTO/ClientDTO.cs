using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTOSample.Code.DTO
{
	 public class ClientDTO
	 {
		  public ClientDTO() { }

		  public int Id { get; set; }
		  public string ClientName { get; set; }
		  public string CountryName { get; set; }
		  public string Address { get; set; }
	 }
}