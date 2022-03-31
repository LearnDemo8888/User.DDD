using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.DDD.Domain.Entities
{
    /// <summary>
    /// 用户登录的历史
    /// </summary>
    public  class UserLoginHistory : EntitieBase
    {


        public string Email { get; private set; }

        public DateTime CreatedDateTime { get; init; }

        public string Messsage { get; private set; }
        public Guid? UserId { get; private set; } //用户ID //跨聚用UserId关联，不用User实体方便日后拆微服务

        private UserLoginHistory()
        {
        }

        public UserLoginHistory(string email, string messsage, Guid? userId)
        {
            Id=Guid.NewGuid();
            Email = email;
            CreatedDateTime = DateTime.Now;
            Messsage = messsage;
            UserId = userId;
        }
    }
}
