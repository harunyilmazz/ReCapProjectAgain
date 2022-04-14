using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public void Display()
        {
            using (RentACarContext context = new RentACarContext())
            {
                List<Rental> entities = context.Set<Rental>().ToList();
                foreach (var item in entities)
                {
                    Console.WriteLine("Id: {0} -- Car Id: {1} -- Customer Id: {2} -- Rent Date: {3} -- Return Date: {4}", item.Id, item.CarId, item.CustomerId, item.RentDate, item.ReturnDate.ToString());
                }
            }
            Console.WriteLine("----------------------------------\n");
        }

        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join cus in context.Customers on r.CustomerId equals cus.Id
                             join u in context.Users on cus.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 CarId = r.CarId,
                                 BrandName = b.BrandName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return filter == null 
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}
