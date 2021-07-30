using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskoMask.Domain.Core.Enums;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Resources;

namespace TaskoMask.Domain.Entities
{
    [Display(Name = nameof(DomainMetadata.User), ResourceType = typeof(DomainMetadata))]
    public class User : ApplicationUser
    {
        public User(string displayName,string email,string userName)
        {
            DisplayName = displayName;
            Email = email;
            UserName = userName;
        }

        public string DisplayName { get; private set; }

        public void SetDisplayName(string displayName)
        {
            DisplayName = displayName;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void SetUserName(string userName)
        {
            UserName = userName;
        }
    }
}
