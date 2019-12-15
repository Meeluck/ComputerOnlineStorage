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
    public class CountryProduceController : Controller
    {
		OnlineStorageContext db = new OnlineStorageContext();

		// Возвращает представление для вывода ин-ии о всех странах производителях
		[HttpGet]
		public ActionResult ShowCountries()
		{
			return View(db.CountryProduces);
		}
		// Возвращает представление для добавления страны производителя
		[HttpGet]
		public ActionResult AddCountry()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddCountry(CountryProduce cp)
		{
			db.CountryProduces.Add(cp);
			db.SaveChanges();
			return RedirectToAction("ShowCountries");
		}
		//Удаление ин-ии о странах производителях
		[HttpGet]
		public ActionResult Delete(int id)
		{
			CountryProduce cp = db.CountryProduces.Find(id);
			if (cp== null)
				return HttpNotFound();
			return View(cp);
		}
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			CountryProduce cp = db.CountryProduces.Find(id);
			if (cp == null)
				return HttpNotFound();
			db.CountryProduces.Remove(cp);
			db.SaveChanges();
			return RedirectToAction("ShowCountries");
		}
		// Редектирование ин-ии о странах производителях
		[HttpGet]
		public ActionResult Edit(int? id)
		{
			if (id == null)
				return HttpNotFound();
			CountryProduce cp = db.CountryProduces.Find(id);
			if (cp == null)
				return HttpNotFound();
			return View(cp);
		}
		[HttpPost]
		public ActionResult Edit(CountryProduce cp)
		{
			db.Entry(cp).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("ShowCountries");
		}
	}
}