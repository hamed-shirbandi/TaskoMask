using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Users;

namespace TaskoMask.Web.Common.Services.Authentication
{
    public interface ICookieAuthenticationService
    {
        Task<bool> SignIn(UserBasicInfoDto user, bool isPersistent);
        Task SignOut();
    }
}