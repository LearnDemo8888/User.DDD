using MediatR;
using User.DDD.Domain.Events;
using User.DDD.Domain.Repositorys;
using User.DDD.Intrastructure;

namespace User.DDD.Application
{
    public class UserAccessResultEventHandler : INotificationHandler<UserAccessResultEvent>
    {
        private readonly IUserRepositrory _userRepositrory;
        private readonly UserDbContext _userDbContext;
        public UserAccessResultEventHandler(IUserRepositrory userRepositrory, UserDbContext userDbContext = null)
        {
            _userRepositrory = userRepositrory;
            _userDbContext = userDbContext;
        }

        public async Task Handle(UserAccessResultEvent notification, CancellationToken cancellationToken)
        {
            await _userRepositrory.AddNewLoginHistoryAsync(notification.Email, $"登录结果是：{notification.Result}");
            await _userDbContext.SaveChangesAsync();
        }
    }
}
