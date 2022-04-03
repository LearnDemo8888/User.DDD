using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.DDD.Core;

namespace User.DDD.Application
{
    public interface ILoginContract
    {

       Task<OperationResult>  LoginByEmailAndPasswordAsync(LoginByEmailAndPasswordDto dto);
    }
}
