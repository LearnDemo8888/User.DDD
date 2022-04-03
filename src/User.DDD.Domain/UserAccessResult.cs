namespace User.DDD.Domain
{
    public enum  UserAccessResult
    {
        OK, EmailNotFound, Lockout,NoPassword, PasswordError
    }
}
