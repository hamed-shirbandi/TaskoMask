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


        
        public string AvatarUrl { get; private set; }
        public string DisplayName { get; private set; }


        public void Update(string displayName, string email, string userName)
        {
            DisplayName = displayName;
            Email = email;
            UserName = userName;

        }
    }
}
