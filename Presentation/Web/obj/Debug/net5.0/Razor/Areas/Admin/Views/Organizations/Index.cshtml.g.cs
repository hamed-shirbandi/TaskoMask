#pragma checksum "C:\Users\PaydarDeveloper\Documents\Visual Studio 2019\Projects\TaskoMask\Presentation\Web\Areas\Admin\Views\Organizations\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6afd4389776e6621677fd34db0f771d3766ac47e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Organizations_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Organizations/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6afd4389776e6621677fd34db0f771d3766ac47e", @"/Areas/Admin/Views/Organizations/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d191da41eca853f6f7b4b372cee018ae94141eb", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Organizations_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TaskoMask.Application.Services.Organizations.Dto.OrganizationOutput>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\PaydarDeveloper\Documents\Visual Studio 2019\Projects\TaskoMask\Presentation\Web\Areas\Admin\Views\Organizations\Index.cshtml"
  
    ViewData["Title"] = "Organizations list";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Organizations list</h2>\r\n<div>\r\n");
#nullable restore
#line 8 "C:\Users\PaydarDeveloper\Documents\Visual Studio 2019\Projects\TaskoMask\Presentation\Web\Areas\Admin\Views\Organizations\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <a");
            BeginWriteAttribute("href", " href=\"", 232, "\"", 325, 1);
#nullable restore
#line 10 "C:\Users\PaydarDeveloper\Documents\Visual Studio 2019\Projects\TaskoMask\Presentation\Web\Areas\Admin\Views\Organizations\Index.cshtml"
WriteAttributeValue("", 239, Url.Action(action:"index",controller:"projects",values:new { organizationId=item.Id}), 239, 86, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 10 "C:\Users\PaydarDeveloper\Documents\Visual Studio 2019\Projects\TaskoMask\Presentation\Web\Areas\Admin\Views\Organizations\Index.cshtml"
                                                                                                    Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n        <br />\r\n");
#nullable restore
#line 12 "C:\Users\PaydarDeveloper\Documents\Visual Studio 2019\Projects\TaskoMask\Presentation\Web\Areas\Admin\Views\Organizations\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TaskoMask.Application.Services.Organizations.Dto.OrganizationOutput>> Html { get; private set; }
    }
}
#pragma warning restore 1591
