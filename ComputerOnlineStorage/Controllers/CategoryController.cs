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
    public class CategoryController : Controller
    {
		OnlineStorageContext db = new OnlineStorageContext();

		//Вовзращает представление для вывода ин-ии о категориях
		[HttpGet]
        public ActionResult ShowCategories()
        {
			return View(db.Categories);
        }

		// Возвращает представление для добавления категорий
		[HttpGet]
		public ActionResult AddCategory()
		{
			//SelectList parentCategory = new SelectList(db.Categories,
			//	"CategoryId", "CategoryName");

			//var parentCategory = db.Categories.Select(p => new
			//{
			//	CategoryId = p.CategoryId,
			//	CategoryName = p.CategoryName
			//});
			//SelectList items = new SelectList(parentCategory);
			//ViewBag.ParentCategory = items;
			return View(/*parentCategory.ToList()*/);
		}
		[HttpPost]
		public ActionResult AddCategory(Category category)
		{
			db.Categories.Add(category);
			db.SaveChanges();
			return RedirectToAction("ShowCategories");
		}
		//Удаоение категорий
		[HttpGet]
		public ActionResult Delete(int id)
		{
			
			Category ct = db.Categories.Find(id);
			if (ct == null)
				return HttpNotFound();
			
			return View(ct);
		}
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			Category ct = db.Categories.Find(id);
			if (ct == null)
				return HttpNotFound();

			db.Categories.Remove(ct);
			db.SaveChanges();
			return RedirectToAction("ShowCategories");
		}
		//Редактирование категорий
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}
			Category ct = db.Categories.Find(id);
			if (ct != null)
			{
				return View(ct);
			}
			return HttpNotFound();
		}
		[HttpPost]
		public ActionResult Edit(Category ct)
		{
			db.Entry(ct).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("ShowCategories");
		}
	}
}