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
    public class ManufactureController : Controller
    {
		OnlineStorageContext db = new OnlineStorageContext();

		// Возвращает представление для вывода ин-ии о всех производителях
		[HttpGet]
		public ActionResult ShowManufactures()
		{
			return View(db.Manufactures);
		}

		// Возвращает представление для добавления производителей
		[HttpGet]
		public ActionResult AddManufacture()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddManufacture(string manufactureName)
		{
			Manufacture manufacture = new Manufacture();
			manufacture.ManufactureName = manufactureName;
			db.Manufactures.Add(manufacture);
			db.SaveChanges();
			return RedirectToAction("ShowManufactures");
		}

		//Удаление ин-ии о производителя
		[HttpGet]
		public ActionResult Delete(int id)
		{
			Manufacture manufacture = db.Manufactures.Find(id);
			if (manufacture == null)
				return HttpNotFound();
			return View(manufacture);
		}
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			Manufacture manufacture = db.Manufactures.Find(id);
			if (manufacture == null)
				return HttpNotFound();
			db.Manufactures.Remove(manufacture);
			db.SaveChanges();
			return RedirectToAction("ShowManufactures");
		}

		// Редектирование ин-ии о производителях
		[HttpGet]
		public ActionResult Edit(int? id)
		{
			if (id == null)
				return HttpNotFound();
			Manufacture manufacture = db.Manufactures.Find(id);
			if (manufacture != null)
				return View(manufacture);
			return HttpNotFound();
		}
		[HttpPost]
		public ActionResult Edit(Manufacture manufacture)
		{
			db.Entry(manufacture).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("ShowManufactures");
		}
	}
}