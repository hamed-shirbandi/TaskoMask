﻿
namespace TaskoMask.Presentation.Framework.Web.Services.Authentication.Models
{
    public class JwtAuthenticationOptions
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int ExpireDays { get; set; }
    }
}
