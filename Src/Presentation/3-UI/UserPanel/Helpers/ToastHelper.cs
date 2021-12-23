using Microsoft.AspNetCore.Components;

namespace TaskoMask.Presentation.UI.UserPanel.Helpers
{
    public static class ToastHelper
    {
        /// <summary>
        /// Parse errors list to html to show by Toast service
        /// </summary>
        public static RenderFragment? ParseToHtml(this List<string> errors)
        {
            RenderFragment? content = null;

            if (!errors.Any())
                return content;

            foreach (var error in errors)
                content += AddMarkupContent( $"<text><strong>-</strong> {error} <br/></text>");

            return content;
        }

     

        /// <summary>
        /// 
        /// </summary>
        private static RenderFragment AddMarkupContent(string txt) => builder =>
        {
            builder.AddMarkupContent(1, txt);
        };

    }
}
