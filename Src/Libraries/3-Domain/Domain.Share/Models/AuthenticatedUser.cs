using TaskoMask.Domain.Share.Enums;

namespace TaskoMask.Domain.Share.Models
{
    public class AuthenticatedUser
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        /// <summary>
        /// To specifying authenticated user type (owner / operator)
        /// </summary>
        public UserType Type { get; set; }


        public bool IsOwner()
        {
            return Type == UserType.Owner;
        }

        public bool IsOperator()
        {
            return Type == UserType.Operator;
        }
    }
}
