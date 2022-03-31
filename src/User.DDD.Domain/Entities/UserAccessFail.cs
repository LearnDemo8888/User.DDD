using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.DDD.Domain.Entities
{
    /// <summary>
    /// 用户访问失败
    /// </summary>
    public record class UserAccessFail
    {
        public Guid Id { get; init; }

        public User User { get; init; }

        public Guid UserId { get; init; }

        private bool isLockOut;

        public DateTime? LockEnd { get; private set; }

        public int AccessFailCount { get; private set; }

        private UserAccessFail()
        {

        }

        public UserAccessFail(User user)
        {
            this.Id = Guid.NewGuid();
            this.User = user;
        }

        public void Reset()
        {
            this.AccessFailCount = 0;
            this.LockEnd = null;
            this.isLockOut = false;
        }

        public void Fail()
        {
            this.AccessFailCount++;
            if (this.AccessFailCount >= 3)
            {
                this.LockEnd = DateTime.Now.AddMinutes(5);
                this.isLockOut=true;
            }
        }

        public bool IsLockOut()
        {

            if (this.isLockOut)
            {
                //已超过了锁定时间
                if (DateTime.Now > this.LockEnd)
                { 
                   Reset();
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
