using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Share.Helpers;

namespace TaskoMask.Domain.Core.Specifications
{
    internal class ValidPasswordSpecification : ISpecification<string>
    {
        public bool IsSatisfiedBy(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            if (password.Length < DomainConstValues.Member_Password_Min_Length)
                return false;

            if (password.Length > DomainConstValues.Member_Password_Max_Length)
                return false;

            return true;
        }
    }
}
