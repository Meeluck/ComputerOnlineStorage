using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ComputerOnlineStorage.Models;
namespace ComputerOnlineStorage.Context
{
	public class OnlineStorageContext :DbContext
	{
		public OnlineStorageContext()
			: base("ComputerOnlineStorage")
		{ }
		
		public DbSet<Manufacture> Manufactures { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
	public class DbInitializer :
			DropCreateDatabaseIfModelChanges<OnlineStorageContext>
	{

		protected override void Seed(OnlineStorageContext db)
		{
			//добавление ин-ии о производителях
			db.Manufactures.Add(new Manufacture { ManufactureId = 1, ManufactureName = "Microsoft" });
			db.Manufactures.Add(new Manufacture { ManufactureId = 2, ManufactureName = "Apple" });
			db.Manufactures.Add(new Manufacture { ManufactureId = 3, ManufactureName = "Intel" });
			db.Manufactures.Add(new Manufacture { ManufactureId = 4, ManufactureName = "Kingson" });
			db.Manufactures.Add(new Manufacture { ManufactureId = 5, ManufactureName = "HyperX" });
			db.Manufactures.Add(new Manufacture { ManufactureId = 6, ManufactureName = "NVidia" });
			db.Manufactures.Add(new Manufacture { ManufactureId = 7, ManufactureName = "Western Digital" });
			db.Manufactures.Add(new Manufacture { ManufactureId = 8, ManufactureName = "Dell" });

			//добавление ин-ии о катагориях
			db.Categories.Add(new Category { CategoryId = 1, ParentCategory = null, CategoryName = "Компьютер" });
			db.Categories.Add(new Category { CategoryId = 2, ParentCategory = 1, CategoryName = "Персональный компьютер" });
			db.Categories.Add(new Category { CategoryId = 3, ParentCategory = 1, CategoryName = "Ноутбук" });
			db.Categories.Add(new Category { CategoryId = 4, ParentCategory = 3, CategoryName = "Игровой ноутбук" });
			db.Categories.Add(new Category { CategoryId = 5, ParentCategory = 3, CategoryName = "Ноутбук для учебы" });

			base.Seed(db);
		}
	}
}