using System;
using System.Linq;

namespace TaskoMask.Web.Helpers
{

    /// <summary>
    /// show notification message by jquery.noty.js
    /// </summary>
    public static class ScriptBox
    {
        
        /// <summary>
        /// 
        /// </summary>
        public static JavaScriptResult ShowMessage(string message, MsgType type = MsgType.alert, bool modal = true, MessageAlignment layout = MessageAlignment.top, bool dismissQueue = false)
        {
            string script = GetMessageScript( message,  type ,  modal,  layout,  dismissQueue ); 
            return new JavaScriptResult(script: script);
        }

 



        /// <summary>
        /// 
        /// </summary>
        public static JavaScriptResult RedirectToUrl(string url, object values=null, string message = "", MsgType messageType=MsgType.success)
        {
            var script = string.Empty;
            var @params = string.Empty;

            if (!string.IsNullOrEmpty(message))
                 script = GetMessageScript(message: message, type:messageType, modal:true,layout:MessageAlignment.topCenter,dismissQueue:false);

            if (values != null)
            {
                @params = String.Join("&", values.GetType().GetProperties().Select(p => p.Name + "=" + p.GetValue(values, null)));
                url = $"{url}?{@params}";
            }

            script += $"window.location.href='{url}';";

            return new JavaScriptResult(script: script);
        }





        /// <summary>
        /// 
        /// </summary>
        public static JavaScriptResult ReloadPage(string message = "", MsgType messageType = MsgType.success)
        {
            var script = string.Empty;

            if (!string.IsNullOrEmpty(message))
                script = GetMessageScript(message: message, type: messageType, modal: true, layout: MessageAlignment.topCenter, dismissQueue: false);
            script += "window.location.reload();";

            return new JavaScriptResult(script: script);
        }




        /// <summary>
        /// 
        /// </summary>
        private static string GetMessageScript(string message, MsgType type, bool modal, MessageAlignment layout, bool dismissQueue)
        {
            return "noty({ text: \"" + message + "\", type: \"" + type.ToString() + "\", layout: \"" + layout + "\", dismissQueue: " + dismissQueue.ToString().ToLower() + ", modal: " + modal.ToString().ToLower() + " });";
        }



    }
}
