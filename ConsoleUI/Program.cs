// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

CarManager carManager = new CarManager(new InMemoryCarDal());
carManager.Display();
Car car = new Car {Id=6, BrandId=6, ColorId=3, ModelYear="2021", DailyPrice=1000, Description= "Kırmızı Ferrari"};
carManager.Add(car);
carManager.Display();
carManager.Update(new Car {Id=6, BrandId=6, ColorId= 4, ModelYear= "2021", DailyPrice= 1100, Description= "Sarı Ferrari"});
carManager.Display();
carManager.Delete(car);
carManager.Display();
