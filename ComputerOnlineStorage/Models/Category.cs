using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerOnlineStorage.Models
{
	public class Category
	{
		[Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CategoryId { get; set; }

		public int? ParentCategory { get; set; }
		[Required, MaxLength(75)]
		public string CategoryName { get; set; }

		public List<Device> Devices { get; set; }
		public Category()
		{
			Devices = new List<Device>();
		}
	}
}