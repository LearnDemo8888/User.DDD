using User.DDD.Application;
using Microsoft.AspNetCore.Mvc;
using User.DDD.Domain.Repositorys;
using User.DDD.Intrastructure;

namespace User.DDD.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepositrory _userRepositrory;
        private readonly UserDbContext _userDbContext;

        public UserController(IUserRepositrory userRepositrory, UserDbContext userDbContext)
        {
            _userRepositrory = userRepositrory;
            _userDbContext = userDbContext;
        }
        [HttpPost]
        public async Task<IActionResult> AddNewUser(AddNewUserDto dto)
        {

     
            if (await _userRepositrory.FindOneAsync(dto.Email) != null)
            {
                return BadRequest("邮箱已存在");
            }

            if (await _userRepositrory.FindByNameAsync(dto.Name) != null)
            {
                return BadRequest("用户名已存在");
            }
            var user = new Domain.Entities.User(dto.Name, dto.Email, dto.PhoneNumber);
            user.ChangePassword(dto.Password);
            _userDbContext.Users.Add(user);
            int count = await _userDbContext.SaveChangesAsync();
            if (count <= 0)
            {
                return BadRequest("保存失败");
            }
            return Ok("添加用户成功");
        }
    }
}
