#pragma checksum "D:\Facultate\1. Master\Semestrul 2\06. Web and Cloud\.NET\Task_WebAndCloud\Views\Shared\PostSummary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53f9cbd1408e9c0e986aa6ff1c8ff5794b14e0c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_PostSummary), @"mvc.1.0.view", @"/Views/Shared/PostSummary.cshtml")]
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
#line 1 "D:\Facultate\1. Master\Semestrul 2\06. Web and Cloud\.NET\Task_WebAndCloud\Views\_ViewImports.cshtml"
using Task_WebAndCloud;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Facultate\1. Master\Semestrul 2\06. Web and Cloud\.NET\Task_WebAndCloud\Views\_ViewImports.cshtml"
using Task_WebAndCloud.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Facultate\1. Master\Semestrul 2\06. Web and Cloud\.NET\Task_WebAndCloud\Views\_ViewImports.cshtml"
using Task_WebAndCloud.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53f9cbd1408e9c0e986aa6ff1c8ff5794b14e0c4", @"/Views/Shared/PostSummary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"081617bbccb65e0171b074ed26ef4cf8f37e1a97", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_PostSummary : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Post>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("  \r\n<div class=\"card card-outline-primary m-1 p-1\">\r\n    <div class=\"bg-faded p-1\">\r\n        <h3>\r\n            ");
#nullable restore
#line 6 "D:\Facultate\1. Master\Semestrul 2\06. Web and Cloud\.NET\Task_WebAndCloud\Views\Shared\PostSummary.cshtml"
       Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <span class=\"badge badge-pill badge-primary align-middle\" style=\"float:right\">\r\n                <small>Category: ");
#nullable restore
#line 8 "D:\Facultate\1. Master\Semestrul 2\06. Web and Cloud\.NET\Task_WebAndCloud\Views\Shared\PostSummary.cshtml"
                            Write(Model.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral(",   ");
#nullable restore
#line 8 "D:\Facultate\1. Master\Semestrul 2\06. Web and Cloud\.NET\Task_WebAndCloud\Views\Shared\PostSummary.cshtml"
                                               Write(Model.PostingDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n            </span>\r\n        </h3>\r\n    </div>\r\n    <div class=\"card-text p-1\">");
#nullable restore
#line 12 "D:\Facultate\1. Master\Semestrul 2\06. Web and Cloud\.NET\Task_WebAndCloud\Views\Shared\PostSummary.cshtml"
                          Write(Model.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    <small>Posted by ");
#nullable restore
#line 13 "D:\Facultate\1. Master\Semestrul 2\06. Web and Cloud\.NET\Task_WebAndCloud\Views\Shared\PostSummary.cshtml"
                Write(Model.UserEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Post> Html { get; private set; }
    }
}
#pragma warning restore 1591
