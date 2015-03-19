
using DTOSample.Code.Data;
using DTOSample.Code.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DTOSample.Code
{
	 [DataObject(true)]
	 public class ClientDatasource
	 {
		  [DataObjectMethod(DataObjectMethodType.Select, false)]
		  public List<ClientDTO> SelectClients()
		  {
				WebsiteDBContext ctx = new WebsiteDBContext();
				var result = (from client in ctx.Clients
								  select new ClientDTO()
								  {
										Id = client.Id,
										ClientName = client.ClientName,
										//Address = (
										//  from addr in ctx.Addresses										  
										//  where addr.Client.Id == client.Id
										//  select addr).FirstOrDefault().ToString(),
										CountryName = (from cty in ctx.Countries 
														  where cty.ID == client.Country.ID 
															  select cty.CountryName).FirstOrDefault()									 
								  }).ToList();

				//Since result is a list of simple DTO objects, this list could be cached

				return result;
		  }


		  bool IsValid(ClientDTO client)
		  {
				if (String.IsNullOrEmpty(client.CountryName))
					 return false;
				if (String.IsNullOrEmpty(client.Address))
					 return false;
				if (client.Address.Split(new char[] { ',' }).Length != 4)
					 return false;

				return true;
		  }

		  [DataObjectMethod(DataObjectMethodType.Insert, false)]
		  public void Insert(ClientDTO client)
		  {
				// Validate your input here !!!!
				if (!IsValid(client))
						  throw new Exception("Invalid data");

				WebsiteDBContext ctx = new WebsiteDBContext();

				// We need to do some conversion now
		
				Country country = (from c in ctx.Countries 
											  where c.CountryName == client.CountryName
											  select c).FirstOrDefault();					 
				if (country == null){
					 country = new Country
					 {
						  CountryName = client.CountryName
					 };
					 ctx.Countries.Add(country);
				}
				string[] addr = client.Address.Split(new[] { ',' });
				Address address = new Address()
				{
					 Street = addr[0],
					 City = addr[1],
					 ZipCode = addr[2],
					 State = addr[3]					 
				};
				ctx.Addresses.Add(address);

				Client newClient = new Client()
				{
					 ClientName = client.ClientName,
					 Country = country,
					 Addresses = new List<Address>(new[] { address })
				};
				
				ctx.Clients.Add(newClient);
				
				ctx.SaveChanges();
		  }

		  [DataObjectMethod(DataObjectMethodType.Update, false)]
		  public void Update(ClientDTO client)
		  {
				WebsiteDBContext ctx = new WebsiteDBContext();
				Client updClient = (from c in ctx.Clients
										  where c.Id == client.Id
										  select c).FirstOrDefault();
				if (updClient != null)
				{
					 updClient.ClientName = client.ClientName;

					 // other update logic which is turns out that this is a bit of a crappy example :-o

					 ctx.SaveChanges();
				}
				else
				{
					 throw new Exception("Customer to update cannot be found ");
				}
		  }

		  [DataObjectMethod(DataObjectMethodType.Delete, false)]
		  public void Delete(ClientDTO client)
		  {
				WebsiteDBContext ctx = new WebsiteDBContext();
				Client remClient = (from c in ctx.Clients 
										  where c.Id == client.Id 
										  select c).FirstOrDefault();
				if (remClient != null)
				{
					 ctx.Clients.Remove(remClient);
					 ctx.SaveChanges();
				}
		  }
	 }
}