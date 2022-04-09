using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.DDD.Domain.Enumerations
{
    public class UserAccessResultType: SmartEnum<UserAccessResultType>
    {

        public static UserAccessResultType OK = new(nameof(OK),1);

        public static UserAccessResultType EmailNotFound = new(nameof(EmailNotFound), 2);

        public static UserAccessResultType Lockout = new(nameof(Lockout), 3);
        public static UserAccessResultType NoPassword = new(nameof(NoPassword), 4);

        public static UserAccessResultType PasswordError = new(nameof(PasswordError), 5);
        public UserAccessResultType(string name, int value) :base(name, value)
        { 
        
        
        }
    }
}
