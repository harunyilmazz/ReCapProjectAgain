using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, RentACarContext>, IBrandDal
    {
        public void Display()
        {
            using (RentACarContext context = new RentACarContext())
            {
                List<Brand> entities = context.Set<Brand>().ToList();
                foreach (var item in entities)
                {
                    Console.WriteLine("Id: {0} -- Brand Name: {1} ", item.Id, item.BrandName);
                }
            }
            Console.WriteLine("------------------------------------\n");
        }
    }
}
