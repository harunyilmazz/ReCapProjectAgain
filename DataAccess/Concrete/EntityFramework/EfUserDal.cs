using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
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
                    Console.WriteLine("Id: {0} -- First Name: {1} -- Last Name: {2} -- Email: {3}", item.Id, item.FirstName, item.LastName, item.Email);
                }
            }
            Console.WriteLine("----------------------------------\n");
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new RentACarContext())
            {
                var result = from oc in context.OperationClaims
                             join uoc in context.UserOperationClaims
                                 on oc.Id equals uoc.OperationClaimId
                             where uoc.UserId == user.Id
                             select new OperationClaim { Id = oc.Id, Name = oc.Name };
                return result.ToList();
            }
        }
    }
}
