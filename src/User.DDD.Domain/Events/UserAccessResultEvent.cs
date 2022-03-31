using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.DDD.Domain.ValueObjects;

namespace User.DDD.Domain.Events
{
    public record class UserAccessResultEvent(string Email, UserAccessResult Result):INotification;
}
