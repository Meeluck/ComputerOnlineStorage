using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ComputerOnlineStorage.Models
{

	public class Manufacture
	{
		[Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ManufactureId { get; set; } 

		[Required, MaxLength(75)]
		public string ManufactureName { get; set; }


	}
}