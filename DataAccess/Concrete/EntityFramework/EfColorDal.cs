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
    public class EfColorDal : EfEntityRepositoryBase<Color, RentACarContext>, IColorDal
    {
        public void Display()
        {
            using (RentACarContext context = new RentACarContext())
            {
                List<Color> entities = context.Set<Color>().ToList();
                foreach (var item in entities)
                {
                    Console.WriteLine("Id: {0} -- Color Name: {1} ", item.Id, item.ColorName);
                }
            }
            Console.WriteLine("------------------------------------\n");
        }
    }
}
