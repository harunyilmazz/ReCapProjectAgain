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
    public class EfUserDal: EfEntityRepositoryBase<User, RentACarContext>, IUserDal
    {
        public void Display()
        {
            using (RentACarContext context = new RentACarContext())
            {
                List<User> entities = context.Set<User>().ToList();
                foreach (var item in entities)
                {
                    Console.WriteLine("Id: {0} -- First Name: {1} -- Last Name: {2} -- Email: {3} -- Password: {4}", item.Id, item.FirstName, item.LastName, item.Email, item.Password);
                }
            }
            Console.WriteLine("----------------------------------\n");
        }
    }
}
