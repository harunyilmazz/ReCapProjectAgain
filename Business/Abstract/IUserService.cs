using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService:IBaseService<User>
    {
        List<OperationClaim> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
    }
}
