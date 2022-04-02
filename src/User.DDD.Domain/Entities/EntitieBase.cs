using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.DDD.Domain.Entities
{
    public abstract class EntitieBase: IAggregateRoot
    {

        public Guid Id { get; init; }
    }
}
