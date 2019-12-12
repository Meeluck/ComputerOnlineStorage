using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ComputerOnlineStorage.Models.People
{
	public class Adress
	{
		[Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AdressId { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public string House { get; set; }
		public string Appartament { get; set; }

		public List<Buyer> Buyers { get; set; }
		public Adress()
		{
			Buyers = new List<Buyer>();
		}
	}
}