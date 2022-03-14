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
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,RentACarContext>, ICustomerDal
    {
        public void Display()
        {
            using (RentACarContext context = new RentACarContext())
            {
                List<Customer> entities = context.Set<Customer>().ToList();
                foreach (var item in entities)
                {
                    Console.WriteLine("Id: {0} -- User Id: {1} -- Company Name: {2}", item.Id, item.UserId, item.CompanyName);
                }
            }
            Console.WriteLine("----------------------------------\n");
        }
    }
}
