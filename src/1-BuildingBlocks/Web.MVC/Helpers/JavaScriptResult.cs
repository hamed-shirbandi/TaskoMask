using Microsoft.AspNetCore.Mvc;

namespace TaskoMask.Services.Monolith.Presentation.Framework.Web.Helpers
{
    public class JavaScriptResult : ContentResult
    {
        public JavaScriptResult(string script)
        {
            this.Content = script;
            this.ContentType = "application/javascript";
        }
    }
}
