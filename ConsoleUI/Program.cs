// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

//CarTest();

//BrandTest();

//ColorTest();

CarDetailDtoTest();

static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    Console.WriteLine("---------- All Car List -----------");
    carManager.Display();
    Console.WriteLine("---------- Added Car List ---------");
    Car car = new Car { Id = 6, BrandId = 5, ColorId = 3, ModelYear = "2021", DailyPrice = 1000, Description = "Kırmızı Ferrari GT" };
    carManager.Add(car);
    carManager.Display();
    Console.WriteLine("--------- Updated Car List -------");
    carManager.Update(new Car { Id = 6, BrandId = 5, ColorId = 4, ModelYear = "2021", DailyPrice = 1100, Description = "Sarı Ferrari GT" });
    carManager.Display();
    Console.WriteLine("--------- Deleted Car List -------");
    carManager.Delete(car);
    carManager.Display();
    Console.WriteLine("--------- White Car List ---------");
    foreach (var item in carManager.GetCarsByColorId(2))
    {
        Console.WriteLine("Id: {0} -- Brand Id: {1} -- Color Id: {2} -- Model Year: {3} -- Daily Price: {4} -- Description: {5}", item.Id, item.BrandId, item.ColorId, item.ModelYear, item.DailyPrice, item.Description);
    }
    Console.WriteLine("----------------------------------\n");
    Console.WriteLine("--------- Kia Car List -----------");
    foreach (var item in carManager.GetCarsByBrandId(3))
    {
        Console.WriteLine("Id: {0} -- Brand Id: {1} -- Color Id: {2} -- Model Year: {3} -- Daily Price: {4} -- Description: {5}", item.Id, item.BrandId, item.ColorId, item.ModelYear, item.DailyPrice, item.Description);
    }
    Console.WriteLine("----------------------------------\n");
}

static void BrandTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    Console.WriteLine("----------- All Brand List ---------");
    brandManager.Display();
    Console.WriteLine("---------- Added Brand List --------");
    Brand brand = new Brand { Id = 6, BrandName = "Honda" };
    brandManager.Add(brand);
    brandManager.Display();
    Console.WriteLine("--------- Updated Brand List -------");
    brandManager.Update(new Brand { Id = 6, BrandName = "Audi" });
    brandManager.Display();
    Console.WriteLine("--------- Deleted Brand List -------");
    brandManager.Delete(brand);
    brandManager.Display();
    Console.WriteLine("----------- One Brand List ---------");
    Brand choosenBrand = brandManager.GetById(4);
    Console.WriteLine("Id: " + choosenBrand.Id + " -- Brand Name: " + choosenBrand.BrandName);
    Console.WriteLine("------------------------------------\n");
}

static void ColorTest()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());
    Console.WriteLine("----------- All Color List ---------");
    colorManager.Display();
    Console.WriteLine("---------- Added Color List --------");
    Color color = new Color { Id = 5, ColorName = "Mavi" };
    colorManager.Add(color);
    colorManager.Display();
    Console.WriteLine("--------- Updated Color List -------");
    colorManager.Update(new Color { Id = 5, ColorName = "Gri" });
    colorManager.Display();
    Console.WriteLine("--------- Deleted Color List -------");
    colorManager.Delete(color);
    colorManager.Display();
    Console.WriteLine("----------- One Color List ---------");
    Color choosenColor = colorManager.GetById(2);
    Console.WriteLine("Id: " + choosenColor.Id + " -- Color Name: " + choosenColor.ColorName);
    Console.WriteLine("------------------------------------\n");
}

static void CarDetailDtoTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    Console.WriteLine("---------- All Car Details -----------");
    foreach (var car in carManager.GetCarDetails())
    {
        Console.WriteLine("Car Name: {0} -- Brand Name: {1} -- Color Name: {2} -- Daily Price: {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
    }
    Console.WriteLine("--------------------------------------\n");
}