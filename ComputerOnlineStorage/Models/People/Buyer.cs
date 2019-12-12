using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComputerOnlineStorage.Models;
namespace ComputerOnlineStorage.Models.People
{
	public class Buyer
	{
		[Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int BuyerId { get; set; }
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public string MobilePhone { get; set; }
		public string Email { get; set; }

		public int? AdressId { get; set; }
		public Adress Adress { get; set; }

		public List<Order> Orders { get; set; }
		public Buyer()
		{
			Orders = new List<Order>();
		}
	}
}