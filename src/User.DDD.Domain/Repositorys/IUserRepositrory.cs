using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.DDD.Domain.Events;
using User.DDD.Domain.ValueObjects;

namespace User.DDD.Domain.Repositorys
{
    /// <summary>
    /// 用户领域
    /// </summary>
    public interface IUserRepositrory
    {
       
        Task<Entities.User?> FindOneAsync(string email);
        Task<Entities.User?> FindOneAsync(Guid userId);

        Task<Entities.User?> FindOneAsync(PhoneNumber phoneNumber);
        Task AddNewLoginHistoryAsync(string email, string msg);

       
        Task SavePhoneNumberCodeAsync(PhoneNumber phoneNumber, string code);
        Task<string?> RetrievePhoneCodeAsync(PhoneNumber phoneNumber);

        Task PublishEventAsync(UserAccessResultEvent @event);
    }
}
