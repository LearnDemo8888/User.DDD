using User.DDD.Domain;
using User.DDD.Domain.ValueObjects;

namespace User.DDD.Intrastructure
{
    public class MockSmsCodeSender : ISmsCodeSender
    {
        public Task SendAsync(PhoneNumber phoneNumber, string code)
        {
            Console.WriteLine($"向{phoneNumber.RegionCode}_{phoneNumber.Number}发送验证码{code}");
            return  Task.CompletedTask;
        }
    }
}
