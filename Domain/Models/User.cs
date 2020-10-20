using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Domain.Core.Enums;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Models
{
    public class User : ApplicationUser
    {
        public User()
        {

        }

        public string DisplayName { get; set; }
    }
}
