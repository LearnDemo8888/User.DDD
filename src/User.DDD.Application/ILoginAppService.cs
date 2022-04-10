using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.DDD.Core;

namespace User.DDD.Application
{
    //Contracts 

    /// <summary>
    /// 应该拆出来还分一层Contracts dto放Contracts层中
    /// </summary>
    public interface ILoginAppService
    {

       Task<OperationResult>  LoginByEmailAndPasswordAsync(LoginByEmailAndPasswordDto dto);
    }
}
