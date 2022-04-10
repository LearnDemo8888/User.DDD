using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.DDD.Core;
using User.DDD.Domain.ValueObjects;

namespace User.DDD.Domain
{
    public interface IUserDomainService
    {

        Task<UserAccessResult> CheckPassword(string email, string password);
       

        Task<CheckCodeResult> CheckPhoneNumber(PhoneNumber phoneNumer, string code);
        


        Task<CheckEmailResult> CheckEmail(string email);
        
        void ResetAccessFail(Entities.User user);
    

         bool IsLockOut(Entities.User user);

        void AccessFail(Entities.User user);




    }
}
