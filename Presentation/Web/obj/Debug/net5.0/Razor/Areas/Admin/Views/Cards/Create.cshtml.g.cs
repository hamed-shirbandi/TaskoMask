#pragma checksum "C:\Users\PaydarDeveloper\Documents\Visual Studio 2019\Projects\TaskoMask\Presentation\Web\Areas\Admin\Views\Cards\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a229f1aaa5431af324c64cf6c11c55942902c174"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Cards_Create), @"mvc.1.0.view", @"/Areas/Admin/Views/Cards/Create.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "C:\Users\PaydarDeveloper\Documents\Visual Studio 2019\Projects\TaskoMask\Presentation\Web\Areas\Admin\Views\_ViewImports.cshtml"
using TaskoMask.web.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\PaydarDeveloper\Documents\Visual Studio 2019\Projects\TaskoMask\Presentation\Web\Areas\Admin\Views\_ViewImports.cshtml"
using TaskoMask.Domain.Core.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a229f1aaa5431af324c64cf6c11c55942902c174", @"/Areas/Admin/Views/Cards/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d191da41eca853f6f7b4b372cee018ae94141eb", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Cards_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TaskoMask.Application.Services.Cards.Dto.CardInput>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\PaydarDeveloper\Documents\Visual Studio 2019\Projects\TaskoMask\Presentation\Web\Areas\Admin\Views\Cards\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h4>Create Card</h4>\r\n<hr />\r\n\r\n");
#nullable restore
#line 11 "C:\Users\PaydarDeveloper\Documents\Visual Studio 2019\Projects\TaskoMask\Presentation\Web\Areas\Admin\Views\Cards\Create.cshtml"
Write(await Html.PartialAsync("_SaveForm", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 17 "C:\Users\PaydarDeveloper\Documents\Visual Studio 2019\Projects\TaskoMask\Presentation\Web\Areas\Admin\Views\Cards\Create.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TaskoMask.Application.Services.Cards.Dto.CardInput> Html { get; private set; }
    }
}
#pragma warning restore 1591
