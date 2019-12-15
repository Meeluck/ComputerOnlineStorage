using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComputerOnlineStorage.Models.People;
namespace ComputerOnlineStorage.Models
{
	public class Order
	{
		[Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderId { get; set; }

		public int BuyerId { get; set; }
		public Buyer Buyer { get; set; }

		public List<Goods> Goods{ get; set; }

		public decimal Coast { get; set; }
		public string Comment { get; set; }

		public Order()
		{
			Goods = new List<Goods>();
		}
	}
}