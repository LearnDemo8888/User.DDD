using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.DDD.Domain.ValueObjects;

namespace User.DDD.Domain
{
    public interface ISmsCodeSender
    {
        Task SendAsync(PhoneNumber phoneNumber, string code);
    }
}
