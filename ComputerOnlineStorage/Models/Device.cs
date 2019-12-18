using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ComputerOnlineStorage.Models 
{ 
	public class Device
	{
		[Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int DeviceId { get; set; }

		public int? ManufactureId { get; set; }
		public Manufacture Manufacture { get; set; }

		public int? CategoryId { get; set; }
		public Category Category { get; set; }

		public virtual ICollection<DeviceCharacteristic> DeviceCharacteristics { get; set; }
		public string DeviceSeries { get; set; }
		public string DeviceModel { get; set; }
		
		public List<Goods> Goods { get; set; }

		public int? CountryId { get; set; }
		public CountryProduce Country { get; set; }
			
		public Device()
		{
			DeviceCharacteristics = new List<DeviceCharacteristic>();
			Goods = new List<Goods>();
		}
	}
}