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

	public class ShowCategories 
	{
		public int CategoryId { get; set; }
		public string ParentCategory { get; set; }
		public string CategoryName { get; set; }
	}

	public class CategoryController : Controller
    {
		OnlineStorageContext db = new OnlineStorageContext();

		//Вовзращает представление для вывода ин-ии о категориях
		[HttpGet]
        public ActionResult ShowCategories()
        {
			var categories = from cat in db.Categories
							 join parCat in db.Categories
							 on cat.ParentCategory equals parCat.CategoryId into temp
							 from t in temp.DefaultIfEmpty()
							 select new ShowCategories
							 {
								 CategoryId = cat.CategoryId,
								 ParentCategory = t.CategoryName,
								 CategoryName = cat.CategoryName
							 };
			return View(categories.ToList());
		}
		
		// Возвращает представление для добавления категорий
		[HttpGet]
		public ActionResult AddCategory()
		{
			var ParentCateg = from cat in db.Categories
							  select new
							  {
								  CategoryId = cat.CategoryId,
								  ParentCategory = cat.CategoryName
							  };
			SelectList sl = new SelectList(ParentCateg,"CategoryId","ParentCategory");
			
			ViewBag.ParentCategory = sl;
			return View();
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
			var categories = from cat in db.Categories
							 join parCat in db.Categories
							 on cat.ParentCategory equals parCat.CategoryId
							 into temp
							 from t in temp.DefaultIfEmpty()
							 select new 
							 {
								 CategoryId = cat.CategoryId,
								 ParentCategory = t.CategoryName
							 };
			foreach(var item in categories)
			{
				if(item.CategoryId == id)
					ViewData["ParentCategory"] = item.ParentCategory;
			}
			

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
			var ParentCateg = from cat in db.Categories
							  select new
							  {
								  CategoryId = cat.CategoryId,
								  ParentCategory = cat.CategoryName
							  };
			SelectList sl = new SelectList(ParentCateg, "CategoryId", "ParentCategory");

			ViewBag.ParentCategory = sl;

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