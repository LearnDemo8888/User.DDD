using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.DDD.Domain
{
    public enum CheckEmailResult
    {
        OK, EmailNotFound, Lockout, EmailError
    }
}
