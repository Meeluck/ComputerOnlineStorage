using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ComputerOnlineStorage.Models
{
	public class DeviceCharacteristic
	{
		[Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int DeviceCharacteristicId { get; set; }
		
		//public int? DeviceId { get; set; }
		//public Device Device { get; set; }
		public virtual ICollection<Device> Devices { get; set; }

		public int? CharacteristicId { get; set; }
		public Characteristics Characteristic { get; set; }

		public string Value { get; set; }

		public DeviceCharacteristic()
		{
			Devices = new List<Device>();
		}
	}
}