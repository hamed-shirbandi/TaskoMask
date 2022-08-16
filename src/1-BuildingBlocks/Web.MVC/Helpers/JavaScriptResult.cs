using Microsoft.AspNetCore.Mvc;

namespace TaskoMask.BuildingBlocks.Web.MVC.Helpers
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
