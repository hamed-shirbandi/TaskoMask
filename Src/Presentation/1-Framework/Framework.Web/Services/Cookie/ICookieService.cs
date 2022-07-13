
namespace TaskoMask.Presentation.Framework.Web.Services.Cookie
{
    public interface  ICookieService
    {
        string Get(string key);
        void Set(string key, string value);
        void Remove(string key);
    }
}
