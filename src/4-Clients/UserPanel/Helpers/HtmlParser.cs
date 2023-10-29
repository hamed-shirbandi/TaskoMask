using Microsoft.AspNetCore.Components;

namespace TaskoMask.Clients.UserPanel.Helpers;

public static class HtmlParser
{
    /// <summary>
    /// Parse errors list to Fragment to show by Toast service
    /// </summary>
    public static RenderFragment ParseToFragment(this List<string> errors)
    {
        RenderFragment content = null;

        if (!errors.Any())
            return content;

        foreach (var error in errors)
            content += AddMarkupContent($"<text><strong>-</strong> {error} <br/></text>");

        return content;
    }

    /// <summary>
    ///
    /// </summary>
    private static RenderFragment AddMarkupContent(string txt) =>
        builder =>
        {
            builder.AddMarkupContent(1, txt);
        };
}
