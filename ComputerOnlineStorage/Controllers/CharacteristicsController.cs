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
	public class CharacteristicsController : Controller
	{
		OnlineStorageContext db = new OnlineStorageContext();

		//Возвращает все доступные характериситики
		[HttpGet]
		public ActionResult ShowCharacteristics()
		{
			return View(db.Characteristics);
		}
		//Возвращает предстваление для добавления новых характеристик
		[HttpGet]
		public ActionResult AddCharacteristic()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddCharacteristic(Characteristics characteristics)
		{
			db.Characteristics.Add(characteristics);
			db.SaveChanges();
			return RedirectToAction("ShowCharacteristics");
		}
		//Удаление характеристики
		[HttpGet]
		public ActionResult Delete(int id)
		{
			Characteristics characteristics = db.Characteristics.Find(id);
			if (characteristics == null)
				return HttpNotFound();
			return View(characteristics);
		}
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			Characteristics characteristics = db.Characteristics.Find(id);
			if (characteristics == null)
				return HttpNotFound();
			db.Characteristics.Remove(characteristics);
			db.SaveChanges();
			return RedirectToAction("ShowCharacteristics");
		}
		//Редактирование характеристики
		[HttpGet]
		public ActionResult Edit(int? id)
		{
			if (id == null)
				return HttpNotFound();
			Characteristics characteristics = db.Characteristics.Find(id);
			if (characteristics == null)
				return HttpNotFound();
			return View(characteristics);
		}
		[HttpPost]
		public ActionResult Edit(Characteristics characteristics)
		{
			db.Entry(characteristics).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("ShowCharacteristics");
		}
	}
}