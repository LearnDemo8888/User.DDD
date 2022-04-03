using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.DDD.Core;
using User.DDD.Domain.Events;
using User.DDD.Domain.Repositorys;
using User.DDD.Domain.ValueObjects;

namespace User.DDD.Domain
{
    public class UserDomainService: IUserDomainService
    {
        private readonly IUserRepositrory _userReposityory;
        private readonly ISmsCodeSender _smsCodeSender;

        public UserDomainService(IUserRepositrory userReposityory, ISmsCodeSender smsCodeSender)
        {
            _userReposityory = userReposityory;
            _smsCodeSender = smsCodeSender;
        }

        public async Task<UserAccessResult> CheckPassword(string email, string password)
        {

            UserAccessResult result;
 
            var user = (await _userReposityory.FindOneAsync(email));
            if (user == null)
            {
                result = UserAccessResult.EmailNotFound;
            }
            else if (IsLockOut(user))
            {
                result = UserAccessResult.Lockout;
            }
            else if (user.HasPassword() == false)
            {
                result = UserAccessResult.NoPassword;
            }
            else if (user.CheckPassword(password))
            {
                result = UserAccessResult.OK;
            }
            else
            {
                result = UserAccessResult.PasswordError;
            }


            if (result == UserAccessResult.OK)
            {
                ResetAccessFail(user);
            }
            else
            {

                AccessFail(user);

            }

            await this._userReposityory.PublishEventAsync(new UserAccessResultEvent(email, result));
            return result;
        }

        public async Task<CheckCodeResult> CheckPhoneNumber(PhoneNumber phoneNumer, string code)
        {

            Entities.User? user = await this._userReposityory.FindOneAsync(phoneNumer);
            if (user == null)
            {

                return CheckCodeResult.PhoneNumberNotFound;
            }
            else if (IsLockOut(user))
            {
                return CheckCodeResult.Lockout;
            }


            string? codeInServer = await _userReposityory.RetrievePhoneCodeAsync(phoneNumer);

            if (codeInServer == null)
            {
                return CheckCodeResult.CodeError;
            }

            if (codeInServer == code)
            {
                return CheckCodeResult.OK;
            }
            else
            {
                AccessFail(user);
                return CheckCodeResult.CodeError;
            }
        
        }


        public async Task<CheckEmailResult> CheckEmail(string email)
        {

            Entities.User? user = await this._userReposityory.FindOneAsync(email);
            if (user == null)
            {

                return CheckEmailResult.EmailNotFound;
            }
            else if (IsLockOut(user))
            {
                return CheckEmailResult.Lockout;
            }



            if (user.Email==email)
            {
                return CheckEmailResult.OK;
            }
            else
            {
                AccessFail(user);
                return CheckEmailResult.EmailError;
            }

        }
        public void ResetAccessFail(Entities.User user)
        {
            user.Access.Reset();
        }

        public bool IsLockOut(Entities.User user)
        {

            return user.Access.IsLockOut();
        }

        public void AccessFail(Entities.User user)
        {

            user.Access.Fail();
        }

        
    }
}
