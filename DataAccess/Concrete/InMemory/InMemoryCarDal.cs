using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{Id= 1, BrandId=1, ColorId= 1, ModelYear="2018", DailyPrice= 300, Description="siyah hundai"},
            new Car{Id= 2, BrandId=2, ColorId= 1, ModelYear="2019", DailyPrice= 400, Description="siyah fiat"},
            new Car{Id= 3, BrandId=3, ColorId= 2, ModelYear="2019", DailyPrice= 500, Description="beyaz renault"},
            new Car{Id= 4, BrandId=4, ColorId= 2, ModelYear="2020", DailyPrice= 800, Description="beyaz kia"},
            new Car{Id= 5, BrandId=5, ColorId= 2, ModelYear="2020", DailyPrice= 800, Description="beyaz alfa romeo"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(carToDelete);
        }

        public void Display()
        {
            foreach (var item in _cars)
            {
                Console.WriteLine("Id: " + item.Id + "  BrandId: " + item.BrandId + "  ColorId: " + item.ColorId + "  Model Year: " + item.ModelYear + "  Daily Price: " + item.DailyPrice + "  Description: " + item.Description); ;
            }
            Console.WriteLine("--------------------------------------------");
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c=>c.Id == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
