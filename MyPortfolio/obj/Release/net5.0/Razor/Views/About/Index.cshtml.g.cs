#pragma checksum "/home/monkey/projets_etna/MyPortefolio/MyPortfolio/Views/About/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc97d863ddc5d5e01b5a943b8814ce571232673c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_About_Index), @"mvc.1.0.view", @"/Views/About/Index.cshtml")]
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
#line 1 "/home/monkey/projets_etna/MyPortefolio/MyPortfolio/Views/_ViewImports.cshtml"
using MyPortfolio;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/monkey/projets_etna/MyPortefolio/MyPortfolio/Views/_ViewImports.cshtml"
using MyPortfolio.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc97d863ddc5d5e01b5a943b8814ce571232673c", @"/Views/About/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e737d9fd9d0060a089574eb594240e3956f238bf", @"/Views/_ViewImports.cshtml")]
    public class Views_About_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MyPortfolio.ViewModels.AboutViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/home/monkey/projets_etna/MyPortefolio/MyPortfolio/Views/About/Index.cshtml"
  
    ViewData["Title"] = "About Me";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>About Me</h1>\n\n<h4>Who I am</h4>\n<hr/>\n\n<div>\n    <p class=\"personnal-description\">");
#nullable restore
#line 13 "/home/monkey/projets_etna/MyPortefolio/MyPortfolio/Views/About/Index.cshtml"
                                Write(Html.DisplayFor(model => model.me.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n    <hr/>\n    <h4>Skills</h4>\n    <p>This is a list of my current skills, since I am study it is bound to grow and will be updated regularly</p>\n    <dl class=\"row\">\n");
#nullable restore
#line 18 "/home/monkey/projets_etna/MyPortefolio/MyPortfolio/Views/About/Index.cshtml"
         foreach (var skill in Model.skills)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dt class=\"col-sm-2\">\n                ");
#nullable restore
#line 21 "/home/monkey/projets_etna/MyPortefolio/MyPortfolio/Views/About/Index.cshtml"
           Write(Html.DisplayFor(modelSkill => skill.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </dt>\n            <dd class=\"col-sm-10\">\n                ");
#nullable restore
#line 24 "/home/monkey/projets_etna/MyPortefolio/MyPortfolio/Views/About/Index.cshtml"
           Write(Html.DisplayFor(modelSkill => skill.List));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </dd>\n");
#nullable restore
#line 26 "/home/monkey/projets_etna/MyPortefolio/MyPortfolio/Views/About/Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </dl>\n    <h4>Contact Informations</h4>\n    <dl class=\"row\">\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 31 "/home/monkey/projets_etna/MyPortefolio/MyPortfolio/Views/About/Index.cshtml"
       Write(Html.DisplayNameFor(model => model.me.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 34 "/home/monkey/projets_etna/MyPortefolio/MyPortfolio/Views/About/Index.cshtml"
       Write(Html.DisplayFor(model => model.me.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 34 "/home/monkey/projets_etna/MyPortefolio/MyPortfolio/Views/About/Index.cshtml"
                                                    Write(Html.DisplayFor(model => model.me.City));

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 34 "/home/monkey/projets_etna/MyPortefolio/MyPortfolio/Views/About/Index.cshtml"
                                                                                              Write(Html.DisplayFor(model => model.me.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 37 "/home/monkey/projets_etna/MyPortefolio/MyPortfolio/Views/About/Index.cshtml"
       Write(Html.DisplayNameFor(model => model.me.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 40 "/home/monkey/projets_etna/MyPortefolio/MyPortfolio/Views/About/Index.cshtml"
       Write(Html.DisplayFor(model => model.me.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 43 "/home/monkey/projets_etna/MyPortefolio/MyPortfolio/Views/About/Index.cshtml"
       Write(Html.DisplayNameFor(model => model.me.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 46 "/home/monkey/projets_etna/MyPortefolio/MyPortfolio/Views/About/Index.cshtml"
       Write(Html.DisplayFor(model => model.me.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </dd>
        <dt class=""col-sm-2"">
            Linkedin
        </dt>
        <dd class=""col-sm-10"">
            <a href=""https://www.linkedin.com/in/vaillant-feuvray/"" target=""_blank"">linkedin.com/in/vaillant-feuvray/</a>
        </dd>
        <dt class=""col-sm-2"">
            GitHub
        </dt>
        <dd class=""col-sm-10"">
            <a href=""https://github.com/VFEUVRAY"" target=""_blank"">github.com/VFEUVRAY</a>
        </dd>
        <dt class=""col-sm-2"">
            Email
        </dt>
        <dd class=""col-sm-10"">
            <a href=""mailto:feuvra_v@etna-alternance.net"" target=""_blank"">feuvra_v@etna-alternance.net</a>
        </dd>
    </dl>
</div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyPortfolio.ViewModels.AboutViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
