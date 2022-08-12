

namespace TaskoMask.Presentation.Framework.Web.Services.Authentication.Models
{
    public class CookieAuthenticationOptions
    {
        public string CookieName { get; set; }
        public bool CookieHttpOnly { get; set; }
        public string LoginPath { get; set; }
        public string LogoutPath { get; set; }
        public int ExpireFromMinute { get; set; }
        public bool SlidingExpiration { get; set; }
        public bool AllowRefresh { get; set; }
    }
}
