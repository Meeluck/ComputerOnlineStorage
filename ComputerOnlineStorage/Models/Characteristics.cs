using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ComputerOnlineStorage.Models
{
	public class Characteristics
	{
		[Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CharacteristicId { get; set; }
		[Required,MaxLength(50)]
		public string CharacteristicName { get; set; } //Наименование характеристики
		public string Measure { get; set; }	//Единица измерения

		public List<DeviceCharacteristic> DeviceCharacteristics { get; set; }
	}
}