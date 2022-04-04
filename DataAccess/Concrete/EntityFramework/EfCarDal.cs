using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,RentACarContext> , ICarDal
    {
        public void Display()
        {
            using (RentACarContext context = new RentACarContext())
            {
                List<Car> entities = context.Set<Car>().ToList();
                foreach (var item in entities)
                {
                    Console.WriteLine("Id: {0} -- Brand Id: {1} -- Color Id: {2} -- Model Year: {3} -- Daily Price: {4} -- Description: {5}", item.Id, item.BrandId, item.ColorId, item.ModelYear, item.DailyPrice, item.Description);
                }
            }
            Console.WriteLine("----------------------------------\n");
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandId = b.Id,
                                 ColorId = cl.Id,
                                 CarName = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 CarImagePath = (from i in context.CarImages where i.CarId == c.Id select i.ImagePath).ToList()
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}
