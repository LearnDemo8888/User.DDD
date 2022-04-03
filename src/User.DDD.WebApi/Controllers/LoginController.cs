using Microsoft.AspNetCore.Mvc;
using User.DDD.Application;
using User.DDD.Core;

namespace User.DDD.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginContract _loginContract;

        public LoginController(ILoginContract loginContract)
        {
            _loginContract = loginContract;
        }

        [HttpPost]

        public async Task<IActionResult> LoginByEmailAndPassword(LoginByEmailAndPasswordDto dto)
        {


           var result= await    _loginContract.LoginByEmailAndPasswordAsync(dto);
            if (result.Type == OperationResultType.Succeed)
            { 
               return Ok(result.Msg);
            }
            return BadRequest(result.Msg);
        }
    }
}
