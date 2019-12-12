using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ComputerOnlineStorage.Models;
namespace ComputerOnlineStorage.Models
{
	public class Goods
	{
		[Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int GoodsId { get; set; }

		public int DeviceId { get; set; }
		public Device Device { get; set; }

		public DataType DateBeginSale { get; set; } //дата начала продаж
		public DataType DateEndSale { get; set; } //дата окончания продаж
		public string Coast { get; set; } //цена товара

		public virtual ICollection<Order> Orders { get; set; }

		public Goods()
		{
			Orders = new List<Order>();	
		}

	}
}