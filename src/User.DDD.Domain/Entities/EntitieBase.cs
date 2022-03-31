using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.DDD.Domain.Entities
{
    public abstract class EntitieBase: IAggregateRoot
    {

        protected Guid Id { get; init; }
    }
}
