namespace AC.Core.Domain.Users
{
    public enum UserLoginResults
    {
        Successful = 1,

        UserNotExist = 2,

        WrongPassword = 3,

        NotActive = 4,

        Deleted = 5, 

        NotRegistered = 6,
    }
}
