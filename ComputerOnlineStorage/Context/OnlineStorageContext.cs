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
			DropCreateDatabaseAlways<OnlineStorageContext>
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
			db.Manufactures.Add(new Manufacture { ManufactureId = 10, ManufactureName = "AMD" });
			db.Manufactures.Add(new Manufacture { ManufactureId = 11, ManufactureName = "Samsung" });

			//добавление ин-ии о катагориях
			db.Categories.Add(new Category { CategoryId = 1, ParentCategory = null, CategoryName = "Компьютер" });
			db.Categories.Add(new Category { CategoryId = 2, ParentCategory = 1, CategoryName = "Персональный компьютер" });
			db.Categories.Add(new Category { CategoryId = 3, ParentCategory = 1, CategoryName = "Ноутбук" });
			db.Categories.Add(new Category { CategoryId = 4, ParentCategory = 3, CategoryName = "Игровой ноутбук" });
			db.Categories.Add(new Category { CategoryId = 5, ParentCategory = 3, CategoryName = "Ноутбук для учебы" });
			db.Categories.Add(new Category { CategoryId = 6, ParentCategory = null, CategoryName = "Комплектуюище компьютера" });
			db.Categories.Add(new Category { CategoryId = 7, ParentCategory = 6, CategoryName = "Процессоры" });
			db.Categories.Add(new Category { CategoryId = 8, ParentCategory = 6, CategoryName = "Оперативная память" });
			db.Categories.Add(new Category { CategoryId = 9, ParentCategory = 6, CategoryName = "SSD" });
			db.Categories.Add(new Category { CategoryId = 10, ParentCategory = 6, CategoryName = "HDD" });
			db.Categories.Add(new Category { CategoryId = 11, ParentCategory = 6, CategoryName = "Видеокарты" });


			//добавление ин-ии о странах 
			db.CountryProduces.Add(new CountryProduce { CountryId = 1, CountryName = "США" });
			db.CountryProduces.Add(new CountryProduce { CountryId = 2, CountryName = "Китай" });
			db.CountryProduces.Add(new CountryProduce { CountryId = 3, CountryName = "Россия" });
			db.CountryProduces.Add(new CountryProduce { CountryId = 4, CountryName = "Тайвань" });
			db.CountryProduces.Add(new CountryProduce { CountryId = 5, CountryName = "Индия" });

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
			db.Characteristics.Add(new Characteristics
			{
				CharacteristicId = 17,
				CharacteristicName = "Название процессора"
			});
			//Описание характеристик
			//DELL G3 15 3579
			//процессор
			DeviceCharacteristic laptop1DC1 = new DeviceCharacteristic
			{
				CharacteristicId = 17,
				Value = "Intel Core i7 8750H"
			};
			 
			DeviceCharacteristic laptop1DC2 = new DeviceCharacteristic
			{
				DeviceCharacteristicId = 1,
				CharacteristicId = 1,
				Value = "6"
			};
			DeviceCharacteristic laptop1DC3 = new DeviceCharacteristic
			{
				DeviceCharacteristicId = 2,
				CharacteristicId = 2,
				Value = "2.2-4.1"
			};
			DeviceCharacteristic laptop1DC4 = new DeviceCharacteristic
			{
				DeviceCharacteristicId = 3,
				CharacteristicId = 3,
				Value = "8"
			};
			//монитор
			DeviceCharacteristic laptop1DC5 = new DeviceCharacteristic
			{
				DeviceCharacteristicId = 4,
				CharacteristicId = 4,
				Value = "1920x1080"
			};
			DeviceCharacteristic laptop1DC6 = new DeviceCharacteristic
			{
				DeviceCharacteristicId = 5,
				CharacteristicId = 5,
				Value = "15,6"
			};
			DeviceCharacteristic laptop1DC7 = new DeviceCharacteristic
			{
				DeviceCharacteristicId = 6,
				CharacteristicId = 6,
				Value = "IPS"
			};
			DeviceCharacteristic laptop1DC8 = new DeviceCharacteristic
			{
				CharacteristicId = 7,
				Value = "60"
			};
			//оперативная память
			DeviceCharacteristic laptop1DC9 = new DeviceCharacteristic
			{
				CharacteristicId = 8,
				Value = "8"
			};
			DeviceCharacteristic laptop1DC10 = new DeviceCharacteristic
			{
				CharacteristicId = 9,
				Value = "2333"
			};
			DeviceCharacteristic laptop1DC11 = new DeviceCharacteristic
			{
				CharacteristicId = 10,
				Value = "ddr4"
			};
			//hdd
			DeviceCharacteristic laptop1DC12 = new DeviceCharacteristic
			{
				CharacteristicId = 11,
				Value = "HDD"
			};
			DeviceCharacteristic laptop1DC13 = new DeviceCharacteristic
			{
				CharacteristicId = 12,
				Value = "1000"
			};
			DeviceCharacteristic laptop1DC14 = new DeviceCharacteristic
			{
				CharacteristicId = 13,
				Value = "5400"
			};
			//ssd
			DeviceCharacteristic laptop1DC15 = new DeviceCharacteristic
			{
				CharacteristicId = 11,
				Value = "SSD"
			};
			DeviceCharacteristic laptop1DC16 = new DeviceCharacteristic
			{
				CharacteristicId = 12,
				Value = "128"
			};
			//видеокарта
			DeviceCharacteristic laptop1DC17 = new DeviceCharacteristic
			{
				CharacteristicId = 14,
				Value = "4"
			};
			DeviceCharacteristic laptop1DC18 = new DeviceCharacteristic
			{
				CharacteristicId = 15,
				Value = "Дискретная"
			};
			DeviceCharacteristic laptop1DC19 = new DeviceCharacteristic
			{
				CharacteristicId = 16,
				Value = "Linux"
			};

			List<DeviceCharacteristic> deviceCharacteristicsLaptop1 = new List<DeviceCharacteristic>
			{
				laptop1DC1, laptop1DC2, laptop1DC3, laptop1DC4, laptop1DC5, laptop1DC6, laptop1DC7, laptop1DC8, laptop1DC9,
				laptop1DC10, laptop1DC11, laptop1DC12, laptop1DC13, laptop1DC14, laptop1DC15, laptop1DC16, laptop1DC17,
				laptop1DC18, laptop1DC19
			};
			db.DeviceCharacteristics.AddRange(deviceCharacteristicsLaptop1);
			Device laptop1 = new Device
			{
				ManufactureId = 8,
				CategoryId = 4,
				DeviceSeries = "G3",
				DeviceModel = "3579",
				CountryId = 2,
				DeviceCharacteristics = deviceCharacteristicsLaptop1
			};
			db.Devices.Add(laptop1);

			//HP Omen 15-dc0017ur
			//процессор
			DeviceCharacteristic laptop2DC1 = new DeviceCharacteristic
			{
				CharacteristicId = 17,
				Value = "Intel Core i7 8750H"
			};

			DeviceCharacteristic laptop2DC2 = new DeviceCharacteristic
			{
				DeviceCharacteristicId = 1,
				CharacteristicId = 1,
				Value = "6"
			};
			DeviceCharacteristic laptop2DC3 = new DeviceCharacteristic
			{
				DeviceCharacteristicId = 2,
				CharacteristicId = 2,
				Value = "2.2-4.1"
			};
			DeviceCharacteristic laptop2DC4 = new DeviceCharacteristic
			{
				DeviceCharacteristicId = 3,
				CharacteristicId = 3,
				Value = "8"
			};
			//монитор
			DeviceCharacteristic laptop2DC5 = new DeviceCharacteristic
			{
				DeviceCharacteristicId = 4,
				CharacteristicId = 4,
				Value = "1920x1080"
			};
			DeviceCharacteristic laptop2DC6 = new DeviceCharacteristic
			{
				DeviceCharacteristicId = 5,
				CharacteristicId = 5,
				Value = "15,6"
			};
			DeviceCharacteristic laptop2DC7 = new DeviceCharacteristic
			{
				DeviceCharacteristicId = 6,
				CharacteristicId = 6,
				Value = "IPS"
			};
			DeviceCharacteristic laptop2DC8 = new DeviceCharacteristic
			{
				CharacteristicId = 7,
				Value = "60"
			};
			//оперативная память
			DeviceCharacteristic laptop2DC9 = new DeviceCharacteristic
			{
				CharacteristicId = 8,
				Value = "12"
			};
			DeviceCharacteristic laptop2DC10 = new DeviceCharacteristic
			{
				CharacteristicId = 9,
				Value = "2666"
			};

			DeviceCharacteristic laptop2DC11 = new DeviceCharacteristic
			{
				CharacteristicId = 10,
				Value = "ddr4"
			};
			//hdd
			DeviceCharacteristic laptop2DC12 = new DeviceCharacteristic
			{
				CharacteristicId = 11,
				Value = "HDD"
			};
			DeviceCharacteristic laptop2DC13 = new DeviceCharacteristic
			{
				CharacteristicId = 12,
				Value = "1000"
			};
			DeviceCharacteristic laptop2DC14 = new DeviceCharacteristic
			{
				CharacteristicId = 13,
				Value = "7200"
			};
			//ssd
			DeviceCharacteristic laptop2DC15 = new DeviceCharacteristic
			{
				CharacteristicId = 11,
				Value = "SSD"
			};
			DeviceCharacteristic laptop2DC16 = new DeviceCharacteristic
			{
				CharacteristicId = 12,
				Value = "128"
			};
			//видеокарта
			DeviceCharacteristic laptop2DC17 = new DeviceCharacteristic
			{
				CharacteristicId = 14,
				Value = "6"
			};
			DeviceCharacteristic laptop2DC18 = new DeviceCharacteristic
			{
				CharacteristicId = 15,
				Value = "Дискретная"
			};
			DeviceCharacteristic laptop2DC19 = new DeviceCharacteristic
			{
				CharacteristicId = 16,
				Value = "Linux"
			};

			List<DeviceCharacteristic> deviceCharacteristicsLaptop2 = new List<DeviceCharacteristic>
			{
				laptop2DC1,laptop2DC2,laptop2DC3,laptop2DC4,laptop2DC5,
				laptop2DC6,laptop2DC7,laptop2DC8,laptop2DC9,laptop2DC10,
				laptop2DC11,laptop2DC12,laptop2DC13,laptop2DC14,laptop2DC15,
				laptop2DC16,laptop2DC17,laptop2DC18,laptop2DC19
			};

			db.DeviceCharacteristics.AddRange(deviceCharacteristicsLaptop2);
			Device laptop2= new Device
			{
				ManufactureId = 9,
				CategoryId = 3,
				DeviceSeries = "Omen",
				DeviceModel = "15-dc0017ur",
				CountryId = 2,
				DeviceCharacteristics = deviceCharacteristicsLaptop2
			};
			db.Devices.Add(laptop2);

			// INTEL Core I9-9900
			DeviceCharacteristic dcForProc1 = new DeviceCharacteristic
			{
				CharacteristicId = 1,
				Value = "8"
			};
			DeviceCharacteristic dcForProc2 = new DeviceCharacteristic
			{
				CharacteristicId = 2,
				Value = "3.1-5.0"
			};
			DeviceCharacteristic dcForProc3 = new DeviceCharacteristic
			{
				CharacteristicId = 3,
				Value = "16"
			};
			List<DeviceCharacteristic> listDeviceCharacteristicsForProc1 = new List<DeviceCharacteristic>
			{
				dcForProc1, dcForProc2,dcForProc3
			};
			db.DeviceCharacteristics.AddRange(listDeviceCharacteristicsForProc1);
			Device intelProc1 = new Device
			{
				ManufactureId = 3,
				CategoryId = 7,
				DeviceCharacteristics = listDeviceCharacteristicsForProc1,
				DeviceSeries = "Core",
				DeviceModel = "I9-9900",
				CountryId = 2
			};
			db.Devices.Add(intelProc1);

			// INTEL Core i7-8700
			DeviceCharacteristic dcForProc4 = new DeviceCharacteristic
			{
				CharacteristicId = 1,
				Value = "16"
			};
			DeviceCharacteristic dcForProc5 = new DeviceCharacteristic
			{
				CharacteristicId = 2,
				Value = "3.2-4.6"
			};
			DeviceCharacteristic dcForProc6 = new DeviceCharacteristic
			{
				CharacteristicId = 3,
				Value = "12"
			};
			List<DeviceCharacteristic> listDeviceCharacteristicsForProc2 = new List<DeviceCharacteristic>
			{
				dcForProc4, dcForProc5,dcForProc6
			};
			db.DeviceCharacteristics.AddRange(listDeviceCharacteristicsForProc2);
			Device intelProc2 = new Device
			{
				ManufactureId = 3,
				CategoryId = 7,
				DeviceCharacteristics = listDeviceCharacteristicsForProc2,
				DeviceSeries = "Core",
				DeviceModel = "I7-8700",
				CountryId = 2
			};
			db.Devices.Add(intelProc2);

			//AMD Ryzen 7 3700X
			DeviceCharacteristic dcForProc7 = new DeviceCharacteristic
			{
				CharacteristicId = 1,
				Value = "8"
			};
			DeviceCharacteristic dcForProc8 = new DeviceCharacteristic
			{
				CharacteristicId = 2,
				Value = "3.6-4.4"
			};
			DeviceCharacteristic dcForProc9 = new DeviceCharacteristic
			{
				CharacteristicId = 3,
				Value = "32"
			};
			List<DeviceCharacteristic> listDeviceCharacteristicsForProc3 = new List<DeviceCharacteristic>
			{
				dcForProc7, dcForProc8,dcForProc9
			};
			db.DeviceCharacteristics.AddRange(listDeviceCharacteristicsForProc3);
			Device amdProc1 = new Device
			{
				ManufactureId = 10,
				CategoryId = 7,
				DeviceCharacteristics = listDeviceCharacteristicsForProc3,
				DeviceSeries = "Ryzen 7",
				DeviceModel = "3700X",
				CountryId = 2
			};
			db.Devices.Add(amdProc1);

			//AMD Ryzen 5 2600X
			DeviceCharacteristic dcForProc10 = new DeviceCharacteristic
			{
				CharacteristicId = 1,
				Value = "6"
			};
			DeviceCharacteristic dcForProc11 = new DeviceCharacteristic
			{
				CharacteristicId = 2,
				Value = "3.6-4.2"
			};
			DeviceCharacteristic dcForProc12 = new DeviceCharacteristic
			{
				CharacteristicId = 3,
				Value = "16"
			};
			List<DeviceCharacteristic> listDeviceCharacteristicsForProc4 = new List<DeviceCharacteristic>
			{
				dcForProc10, dcForProc11,dcForProc12
			};
			db.DeviceCharacteristics.AddRange(listDeviceCharacteristicsForProc4);
			Device amdProc2 = new Device
			{
				ManufactureId = 10,
				CategoryId = 7,
				DeviceCharacteristics = listDeviceCharacteristicsForProc4,
				DeviceSeries = "Ryzen 5",
				DeviceModel = "2600X",
				CountryId = 2
			};
			db.Devices.Add(amdProc2);

			//Kingston HyperX Predator DDR4 DIMM 8 Гб PC4-26600 1 шт.
			DeviceCharacteristic dcForRam1 = new DeviceCharacteristic
			{
				CharacteristicId = 8,
				Value = "8"
			};
			DeviceCharacteristic dcForRam2 = new DeviceCharacteristic
			{
				CharacteristicId = 9,
				Value = "3333"
			};
			DeviceCharacteristic dcForRam3 = new DeviceCharacteristic
			{
				CharacteristicId = 10,
				Value = "DDR4"
			};
			List<DeviceCharacteristic> listDeviceCharacteristicsForRam1 = new List<DeviceCharacteristic>
			{
				dcForRam1,dcForRam2,dcForRam3
			};
			db.DeviceCharacteristics.AddRange(listDeviceCharacteristicsForRam1);
			Device kingstonRam1 = new Device
			{
				ManufactureId = 4,
				CategoryId = 8,
				DeviceCharacteristics = listDeviceCharacteristicsForRam1,
				DeviceSeries = "HyperX Predator",
				DeviceModel = "HX433C16PB3"
			};
			db.Devices.Add(kingstonRam1);

			//Kingston HyperX Fury DDR4 DIMM 16 Гб PC4-25600 1 шт. (HX432C16FB3 / 16)
			DeviceCharacteristic dcForRam4 = new DeviceCharacteristic
			{
				CharacteristicId = 8,
				Value = "16"
			};
			DeviceCharacteristic dcForRam5 = new DeviceCharacteristic
			{
				CharacteristicId = 9,
				Value = "3200"
			};
			DeviceCharacteristic dcForRam6 = new DeviceCharacteristic
			{
				CharacteristicId = 10,
				Value = "DDR4"
			};
			List<DeviceCharacteristic> listDeviceCharacteristicsForRam2 = new List<DeviceCharacteristic>
			{
				dcForRam4,dcForRam5,dcForRam6
			};
			db.DeviceCharacteristics.AddRange(listDeviceCharacteristicsForRam2);
			Device kingstonRam2 = new Device
			{
				ManufactureId = 4,
				CategoryId = 8,
				DeviceCharacteristics = listDeviceCharacteristicsForRam2,
				DeviceSeries = " HyperX Fury",
				DeviceModel = "HX432C16FB"
			};
			db.Devices.Add(kingstonRam2);


			base.Seed(db);
		}
	}
}