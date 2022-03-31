using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.DDD.Domain.ValueObjects;

namespace User.DDD.Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class User : EntitieBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }

        public DateTime CreatedTime { get; private set; }

      

        public PhoneNumber PhoneNumber { get; private set; }

        public UserAccessFail Access { get; private set; }

        private string? password;

        /// <summary>
        /// 
        /// </summary>
        private User()
        {
        }

        public User(string name, string email, PhoneNumber phoneNumber)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.CreatedTime=DateTime.Now;
            this.Access= new UserAccessFail(this);
        }

        public void UpdateName(string name)
        {

            var oldName = this.Name;
            this.Name = name;
        }

        public void ChangePassword(string password)
        {

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentOutOfRangeException("密码不能粉空");
            }

            if (password.Length < 6)
            {
                throw new ArgumentOutOfRangeException("密码不能少于6位");

            }
            this.password = MD5Helper.MD5Encrypt16(password);
        }

        public bool CheckPassword(string password)
        { 
         
            return this.password==MD5Helper.MD5Encrypt16(password);  
        }

        public bool HasPassword() {
            return !string.IsNullOrEmpty(this.password);
        }

        public void ChagePhoneNumber(PhoneNumber phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }

    }
}
