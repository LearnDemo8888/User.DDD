using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.DDD.Domain.ValueObjects
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="RegionCode">国家代码</param>
    /// <param name="Number">手机号</param>
    public record class PhoneNumber(int RegionCode, string Number);

}
