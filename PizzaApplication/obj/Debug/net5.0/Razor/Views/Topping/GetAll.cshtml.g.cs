#pragma checksum "C:\KANINI\PizzaApplicationProject\PizzaFrontEnd\PizzaApplication\Views\Topping\GetAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf3d403b1fdecb201e4c81fc38c15b6267c05ea0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Topping_GetAll), @"mvc.1.0.view", @"/Views/Topping/GetAll.cshtml")]
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
#line 1 "C:\KANINI\PizzaApplicationProject\PizzaFrontEnd\PizzaApplication\Views\_ViewImports.cshtml"
using PizzaApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\KANINI\PizzaApplicationProject\PizzaFrontEnd\PizzaApplication\Views\_ViewImports.cshtml"
using PizzaApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf3d403b1fdecb201e4c81fc38c15b6267c05ea0", @"/Views/Topping/GetAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ba295415eabbe47cee94bfd856e3b8f99d2f3b1", @"/Views/_ViewImports.cshtml")]
    public class Views_Topping_GetAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PizzaApplication.Models.ToppingDTO>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"card-columns\">\r\n\r\n");
#nullable restore
#line 5 "C:\KANINI\PizzaApplicationProject\PizzaFrontEnd\PizzaApplication\Views\Topping\GetAll.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card text-center\" style=\"width: 18rem;\">\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\"> ");
#nullable restore
#line 9 "C:\KANINI\PizzaApplicationProject\PizzaFrontEnd\PizzaApplication\Views\Topping\GetAll.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n            </div>\r\n            <ul class=\"list-group list-group-flush\">\r\n                <li class=\"list-group-item\">Price : ");
#nullable restore
#line 13 "C:\KANINI\PizzaApplicationProject\PizzaFrontEnd\PizzaApplication\Views\Topping\GetAll.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n\r\n                <li class=\"list-group-item\">Speciality :  ");
#nullable restore
#line 15 "C:\KANINI\PizzaApplicationProject\PizzaFrontEnd\PizzaApplication\Views\Topping\GetAll.cshtml"
                                                     Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n\r\n                <li class=\"list-group-item\">\r\n                    <div class=\"btn btn-outline-danger\">\r\n\r\n                        ");
#nullable restore
#line 20 "C:\KANINI\PizzaApplicationProject\PizzaFrontEnd\PizzaApplication\Views\Topping\GetAll.cshtml"
                   Write(Html.ActionLink("Add Topping", "Select_This", new { id = item.ToppingId }, new { @style = "color: #540615 ; text-decoration: none ;" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </div>\r\n                </li>\r\n            </ul>\r\n\r\n");
            WriteLiteral("        </div>      ");
#nullable restore
#line 32 "C:\KANINI\PizzaApplicationProject\PizzaFrontEnd\PizzaApplication\Views\Topping\GetAll.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PizzaApplication.Models.ToppingDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
