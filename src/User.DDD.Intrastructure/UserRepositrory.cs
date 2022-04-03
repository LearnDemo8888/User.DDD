using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using User.DDD.Domain.Entities;
using User.DDD.Domain.Events;
using User.DDD.Domain.Repositorys;
using User.DDD.Domain.ValueObjects;

namespace User.DDD.Intrastructure
{
    public class UserRepositrory : IUserRepositrory
    {

        private readonly UserDbContext _userDbContext;
        private readonly IDistributedCache _distributedCache;
        private readonly IMediator _imediator;


        public UserRepositrory(UserDbContext userDbContext, IDistributedCache distributedCache, IMediator imediator)
        {
            _userDbContext = userDbContext;
            _distributedCache = distributedCache;
            _imediator = imediator;
        }

        public async Task AddNewLoginHistoryAsync(string email, string msg)
        {
            var user = await FindOneAsync(email); 
             _userDbContext.UserLoginHistories.Add(new UserLoginHistory(email,msg, user?.Id));
   
        }

        public  Task<Domain.Entities.User?> FindOneAsync(string email)
        {
           return  _userDbContext.Users.FirstOrDefaultAsync(o => o.Email == email);
        }

        public  Task<Domain.Entities.User?> FindOneAsync(Guid userId)
        {
            return  _userDbContext.Users.FindAsync(userId).AsTask();
        }

        public  Task<Domain.Entities.User?> FindOneAsync(PhoneNumber phoneNumber)
        {
            return _userDbContext.Users.Where(u=>u.PhoneNumber.Number== phoneNumber.Number && u.PhoneNumber.RegionCode==phoneNumber.RegionCode).FirstOrDefaultAsync();
        }

        public  async Task PublishEventAsync(UserAccessResultEvent @event)
        {
            await _imediator.Publish(@event);
        }

        public async Task<string?> RetrievePhoneCodeAsync(PhoneNumber phoneNumber)
        {
            var key = $"PhoneNumberCode_{phoneNumber.RegionCode}_{ phoneNumber.Number}";
            string? code = await _distributedCache.GetStringAsync(key);
            await _distributedCache.RemoveAsync(key);
            return code;
        }

        public  Task SavePhoneNumberCodeAsync(PhoneNumber phoneNumber, string code)
        {
            var key = $"PhoneNumberCode_{phoneNumber.RegionCode}_{ phoneNumber.Number}";

            return _distributedCache.SetStringAsync(key, code, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)

            }); 
        }

        public Task<Domain.Entities.User?> FindByNameAsync(string name)
        { 
        
          return _userDbContext.Users.Where(u=>u.Name==name).FirstOrDefaultAsync();
        }
    }
}
