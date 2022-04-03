using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.DDD.Domain.ValueObjects;

namespace User.DDD.Application
{
    public record  AddNewUserDto(string Email, string Name,string Password, PhoneNumber PhoneNumber);
 
}
