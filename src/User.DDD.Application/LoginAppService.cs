using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.DDD.Core;
using User.DDD.Domain;
using User.DDD.Intrastructure;

namespace User.DDD.Application
{
    public class LoginAppService : ILoginAppService
    {
        private readonly UserManager _userManager;
        private readonly UserDbContext _userDbContext;

        public LoginAppService(UserManager userManager, UserDbContext userDbContext = null)
        {
            _userManager = userManager;
            _userDbContext = userDbContext;
        }

        public async Task<OperationResult> LoginByEmailAndPasswordAsync(LoginByEmailAndPasswordDto dto)
        {
            OperationResult result = new OperationResult();
            if (dto.Password.Length <6)
            {
                result.Type = OperationResultType.Fail;
                result.Msg = "密码长度不能小于6";
            }
            UserAccessResult userAccessResult=  await _userManager.CheckPassword(dto.Email,dto.Password);
            switch (userAccessResult)
            {

                case UserAccessResult.OK:
                    result.Type = OperationResultType.Succeed;
                    result.Msg = "登录成功";
                    break;
                case UserAccessResult.EmailNotFound:
                    result.Type = OperationResultType.Fail;
                    result.Msg = "Email不存在";
                    break;
                case UserAccessResult.Lockout:
                    result.Type = OperationResultType.Fail;
                    result.Msg = "用户已锁定";
                    break;
                case UserAccessResult.NoPassword:
                    result.Type = OperationResultType.Fail;
                    result.Msg = "密码不存在";
                    break;
                case UserAccessResult.PasswordError:
                    result.Type = OperationResultType.Fail;
                    result.Msg = "密码错误";
                    break;

            }

            await  _userDbContext.SaveChangesAsync();
    
            return result;
        }
    }
}
