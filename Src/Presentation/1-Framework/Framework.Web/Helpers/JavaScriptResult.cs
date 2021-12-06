using Microsoft.AspNetCore.Mvc;

namespace TaskoMask.Presentation.Framework.Web.Helpers
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
