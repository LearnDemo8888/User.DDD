using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.DDD.Application
{
    public record class LoginByEmailAndPasswordDto(string Email,string Password);
 
}
