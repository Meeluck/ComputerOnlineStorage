using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerOnlineStorage.Models
{
	public class CountryProduce
	{
		[Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CountryId { get; set; }
		public string CountryName { get; set; }
		public List<Device> Devices { get; set; }

		public CountryProduce()
		{
			Devices = new List<Device>();
		}
	}
}