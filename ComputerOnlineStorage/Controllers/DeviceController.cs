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

            return View(devices.ToList());
        }
    }
}