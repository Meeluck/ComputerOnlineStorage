using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ComputerOnlineStorage.Models;
using ComputerOnlineStorage.Context;

namespace ComputerOnlineStorage.Controllers
{
	
	public class ShowDevice
	{
		public int DeviceId { get; set; }
		public string Manufacture { get; set; }
		public string Category { get; set; }
		public string DeviceSeries { get; set; }
		public string DeviceModel { get; set; }
	}

	public class DeviceMoreInfo: ShowDevice
	{
		public string Country { get; set; }
		public List<string> Characteristics { get; set; }
		public DeviceMoreInfo()
		{
			Characteristics = new List<string>();
		}
	}
    public class DeviceController : Controller
    {
		OnlineStorageContext db = new OnlineStorageContext();
        // GET: Device
        public ActionResult ShowDevices()
        {
			var devices = from dev in db.Devices
						  join man in db.Manufactures on dev.ManufactureId equals man.ManufactureId
						  join cat in db.Categories on dev.CategoryId equals cat.CategoryId
						  select new ShowDevice
						  {
							  DeviceId = dev.DeviceId,
							  Manufacture = man.ManufactureName,
							  Category = cat.CategoryName,
							  DeviceModel = dev.DeviceModel,
							  DeviceSeries = dev.DeviceSeries
						  };

			var manufacture = (from dev in db.Devices
							   join man in db.Manufactures on dev.ManufactureId equals man.ManufactureId into temp
							   from t in temp
							   select new
							   {
								   ManufactureId = t.ManufactureId,
								   ManufactureName = t.ManufactureName
							   }).Distinct();


			SelectList manufactures = new SelectList(manufacture, "ManufactureId", "ManufactureName");
			ViewBag.manufactures = manufactures;


			return View(devices.ToList());
        }

		[HttpPost]
		public ActionResult ShowByManufacture(string ManufactureName)
		{
			int manufactureId = Convert.ToInt32(ManufactureName);

			var devices = from dev in db.Devices
						  join man in db.Manufactures on dev.ManufactureId equals man.ManufactureId
						  join cat in db.Categories on dev.CategoryId equals cat.CategoryId
						  where dev.ManufactureId == manufactureId
						  select new ShowDevice
						  {
							  DeviceId = dev.DeviceId,
							  Manufacture = man.ManufactureName,
							  Category = cat.CategoryName,
							  DeviceModel = dev.DeviceModel,
							  DeviceSeries = dev.DeviceSeries
						  };

			return View(devices.ToList());
		}
		
		public ActionResult MoreInfo(int id)
		{

			DeviceMoreInfo device = new DeviceMoreInfo();

			var mainInfoDevice = from dev in db.Devices
								 join man in db.Manufactures on dev.ManufactureId equals man.ManufactureId
								 join cat in db.Categories on dev.CategoryId equals cat.CategoryId
								 join country in db.CountryProduces on dev.CountryId equals country.CountryId into temp
								 from t in temp.DefaultIfEmpty()
								 where dev.DeviceId == id
								 select new DeviceMoreInfo
								 {
									 DeviceId = dev.DeviceId,
									 Manufacture = man.ManufactureName,
									 Category = cat.CategoryName,
									 DeviceModel = dev.DeviceModel,
									 DeviceSeries = dev.DeviceSeries,
									 Country = t.CountryName
								 };

			foreach(var item in mainInfoDevice)
			{
				device.DeviceId = item.DeviceId;
				device.Manufacture = item.Manufacture;
				device.Category = item.Category;
				device.DeviceModel = item.DeviceModel;
				device.DeviceSeries = item.DeviceSeries;
				device.Country = item.Country;
			 }

			var characteristics = from devChar in db.DeviceCharacteristics
								  join character in db.Characteristics
								  on devChar.CharacteristicId equals character.CharacteristicId into temp
								  from t in temp.DefaultIfEmpty()
								  where devChar.DeviceId == id
								  select new
								  {
									  Characteristics = t.CharacteristicName + " " + devChar.Value + " " + t.Measure
								  };
			foreach (var item in characteristics)
			{
				device.Characteristics.Add(item.Characteristics);
			}
			//Обработать ситуайию с left join
			return View(device);
		}
    }
}