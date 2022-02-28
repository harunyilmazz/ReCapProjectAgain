// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

CarManager carManager = new CarManager(new EfCarDal());
Console.WriteLine("---------- All Car List -----------");
carManager.Display();
Console.WriteLine("---------- Added Car List ---------");
Car car = new Car {Id=6, BrandId=5, ColorId=3, ModelYear="2021", DailyPrice=1000, Description= "Kırmızı Ferrari GT"};
carManager.Add(car);
carManager.Display();
Console.WriteLine("--------- Updated Car List -------");
carManager.Update(new Car {Id=6, BrandId=5, ColorId= 4, ModelYear= "2021", DailyPrice= 1100, Description= "Sarı Ferrari GT"});
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