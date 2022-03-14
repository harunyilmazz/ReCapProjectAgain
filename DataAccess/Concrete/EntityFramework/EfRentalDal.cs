using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepositoryBase<Rental,RentACarContext>, IRentalDal
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
    }
}
