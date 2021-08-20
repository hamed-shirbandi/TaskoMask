using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Users.Queries.Models
{
    public class ValidateUserPasswordQuery : BaseQuery<bool>
    {
        public ValidateUserPasswordQuery(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; }
        public string Password { get; }
    }
}
