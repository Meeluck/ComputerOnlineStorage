using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ComputerOnlineStorage.Models;
using ComputerOnlineStorage.Models.People;
namespace ComputerOnlineStorage.Context
{
	public class OnlineStorageContext : DbContext
	{
		public OnlineStorageContext()
			: base("ComputerOnlineStorage")
		{ }

		public DbSet<Manufacture> Manufactures { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Characteristics> Characteristics { get; set; }
		public DbSet<DeviceCharacteristic> DeviceCharacteristics { get; set; }
		public DbSet<CountryProduce> CountryProduces { get; set; }
		public DbSet<Device> Devices { get; set; }

		public DbSet<Buyer> Buyers { get; set; }
		public DbSet<Adress> Adresses { get; set; }

		public DbSet<Order> Orders { get; set; }
		public DbSet<Goods> Goods { get; set; }
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
			db.Manufactures.Add(new Manufacture { ManufactureId = 9, ManufactureName = "HP" });

			//добавление ин-ии о катагориях
			db.Categories.Add(new Category { CategoryId = 1, ParentCategory = null, CategoryName = "Компьютер" });
			db.Categories.Add(new Category { CategoryId = 2, ParentCategory = 1, CategoryName = "Персональный компьютер" });
			db.Categories.Add(new Category { CategoryId = 3, ParentCategory = 1, CategoryName = "Ноутбук" });
			db.Categories.Add(new Category { CategoryId = 4, ParentCategory = 3, CategoryName = "Игровой ноутбук" });
			db.Categories.Add(new Category { CategoryId = 5, ParentCategory = 3, CategoryName = "Ноутбук для учебы" });


			//добавление ин-ии о странах 
			db.CountryProduces.Add(new CountryProduce { CountryId = 1, CountryName = "USA" });
			db.CountryProduces.Add(new CountryProduce { CountryId = 2, CountryName = "China" });
			db.CountryProduces.Add(new CountryProduce { CountryId = 3, CountryName = "Russia" });
			db.CountryProduces.Add(new CountryProduce { CountryId = 4, CountryName = "Taiwan" });
			db.CountryProduces.Add(new CountryProduce { CountryId = 5, CountryName = "India" });

			//ДОБАВЛЕНИЕ ХАРАКТЕРИСТИК
				//основные характеристики процесссоров
			db.Characteristics.Add(new Characteristics
			{
				CharacteristicId = 1,
				CharacteristicName = "Количество ядер процессорв"
			});
			db.Characteristics.Add(new Characteristics
			{
				CharacteristicId = 2,
				CharacteristicName = "Частота процессора",
				Measure = "ГГц"
			});
			db.Characteristics.Add(new Characteristics
			{
				CharacteristicId = 3,
				CharacteristicName = "Кэш процессора",
				Measure = "МБ"
			});
				//основыне характеристики дисплев
			db.Characteristics.Add(new Characteristics
			{
				CharacteristicId = 4,
				CharacteristicName = "Разрешение дисплея",
			});
			db.Characteristics.Add(new Characteristics
			{
				CharacteristicId = 5, 
				CharacteristicName = "Диагональ экрана"
			});
			db.Characteristics.Add(new Characteristics
			{
				CharacteristicId = 6,
				CharacteristicName = "Тип матриы"
			});
			db.Characteristics.Add(new Characteristics
			{
				CharacteristicId = 7,
				CharacteristicName = "Частота обновления экрана",
				Measure = "Гц"
			});
				//основные характеристики оперативной памяти
			db.Characteristics.Add(new Characteristics
			{
				CharacteristicId = 8,
				CharacteristicName = "Объем оперативной памяти",
				Measure = "МБ"
			});
			db.Characteristics.Add(new Characteristics
			{
				CharacteristicId = 9,
				CharacteristicName = "Частота оперативной памяти",
				Measure = "МГц"
			});
			db.Characteristics.Add(new Characteristics
			{
				CharacteristicId = 10,
				CharacteristicName = "Тип оперативной памяти" //ddr4 or ddr3
			});
				//устройства хранения данных
			db.Characteristics.Add(new Characteristics
			{
				CharacteristicId = 11,
				CharacteristicName = "Тип запоминающего устройства" //ssd or hd
			});
			db.Characteristics.Add(new Characteristics
			{
				CharacteristicId = 12,
				CharacteristicName = "Объём запоминающего устройства",
				Measure = "Гб"
			});
			db.Characteristics.Add(new Characteristics
			{
				CharacteristicId = 13,
				CharacteristicName = "Скорость работы HDD",
				Measure = "об/мин"
			});
				//Видеокарта
			db.Characteristics.Add(new Characteristics
			{
				CharacteristicId = 14,
				CharacteristicName = "Объем видеопамяти",
				Measure = "Гб"
			});
			db.Characteristics.Add(new Characteristics
			{
				CharacteristicId = 15,
				CharacteristicName = "Тип видеокарты" //встроенная или дискретная
			});
				//Опеационная система
			db.Characteristics.Add(new Characteristics
			{
				CharacteristicId = 16,
				CharacteristicName = "Операционная система"
			});


			base.Seed(db);
		}
	}
}